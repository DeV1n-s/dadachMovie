using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;
using Gridify.EntityFramework;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class MoviesService : BaseService, IMoviesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private readonly ILoggerService _logger;
        private readonly ICommentService _commentService;
        private readonly IAccountsService _accountsService;
        private readonly IPeopleService _peopleService;
        private readonly IRatingService _ratingService;
        private readonly IUserFavoriteService _userFavoriteService;
        private readonly string _containerName = "movies";

        public MoviesService(AppDbContext dbContext,
                            IMapper mapper,
                            IFileStorageService fileStorageService,
                            ILoggerService logger,
                            ICommentService commentService,
                            IAccountsService accountsService,
                            IPeopleService peopleService,
                            IRatingService ratingService,
                            IUserFavoriteService userFavoriteService)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
            _logger = logger;
            _commentService = commentService;
            _accountsService = accountsService;
            _peopleService = peopleService;
            _ratingService = ratingService;
            _userFavoriteService = userFavoriteService;
        }
        public async Task<Paging<MovieDTO>> GetMoviesPagingAsync(int? genreId, GridifyQuery gridifyQuery)
        {
            var movies = _dbContext.Movies.AsNoTracking()
                                        .Include(x => x.Genres);
            
            var queryable = await movies.GridifyQueryableAsync(gridifyQuery, null);

            if (genreId != null)
            {
                queryable = await movies.Where(x => x.Genres.Any(x => x.Id == genreId))
                                        .GridifyQueryableAsync(gridifyQuery, null);
            }

            return new Paging<MovieDTO> {Items = queryable.Query.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }

        public async Task<MovieDetailsDTO> GetMovieByIdAsync(int id) =>
            await _dbContext.Movies.AsNoTracking()
                                .ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(m => m.Id == id);
        
        public async Task<Paging<MovieDTO>> GetMoviesByGenreIdPagingAsync(int id, GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Movies.AsNoTracking()
                                                .Include(x => x.Genres)
                                                .Where(x => x.Genres.Any(x => x.Id == id))
                                                .GridifyQueryableAsync(gridifyQuery,null);

            return new Paging<MovieDTO> {Items = queryable.Query.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }
            
        public async Task<Paging<MovieDTO>> GetUpcomingReleasesAsync(GridifyQuery gridifyQuery)
        {
            var today = DateTime.Today;
            var queryable = await _dbContext.Movies
                .AsNoTracking()
                .Where(x => x.ReleaseDate > today)
                .GridifyQueryableAsync(gridifyQuery,null);

            return new Paging<MovieDTO> {Items = queryable.Query.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider).ToList(),
                                                TotalItems = queryable.TotalItems};
        }

        public async Task<Paging<MovieDTO>> GetInTheatersAsync(GridifyQuery gridifyQuery)
        {
            var today = DateTime.Today;
            var queryable = await _dbContext.Movies
                .AsNoTracking()
                .Where(x => x.InTheaters)
                .GridifyQueryableAsync(gridifyQuery,null);

            return new Paging<MovieDTO> {Items = queryable.Query.ProjectTo<MovieDTO>(_mapper.ConfigurationProvider).ToList(),
                                                TotalItems = queryable.TotalItems};
        }

        public IQueryable<MovieDetailsDTO> GetMoviesDetailsQueryable() =>
            _dbContext.Movies.AsNoTracking()
                            .ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                            .AsQueryable();
        
        public IQueryable<Movie> GetMoviesQueryable() =>
            _dbContext.Movies.AsNoTracking().AsQueryable();

        public async Task<MovieDTO> AddMovieAsync(MovieCreationDTO movieCreationDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreationDTO);

            if (movieCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await movieCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(movieCreationDTO.Picture.FileName);
                    movie.Picture = 
                        await _fileStorageService.SaveFile(content, extension, _containerName,
                                                            movieCreationDTO.Picture.ContentType);
                }
            }

            if (movieCreationDTO.BannerImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await movieCreationDTO.BannerImage.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(movieCreationDTO.BannerImage.FileName);
                    movie.BannerImage = 
                        await _fileStorageService.SaveFile(content, extension, _containerName,
                                                            movieCreationDTO.BannerImage.ContentType);
                }
            }

            this.AnnotateCastsOrder(movie);
            await SetMovieDirectorsGenresCastsListAsync(movie, movieCreationDTO);
            await AddCategoryToPerson(movie);

            _dbContext.Add(movie);
            try
            {
                await this.SaveChangesAsync();
                _logger.LogInfo($"Movie with ID {movie.Id} was added successfully.");
                await SetMovieRatingsAsync(movie);
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to add movie {movie.Id}. Exception: {ex}");
            }
            
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task<int> UpdateMovieAsync(int id, MovieCreationDTO movieCreationDTO)
        {
            var movieDb = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movieDb == null)
            {
                _logger.LogWarn($"Movie with ID {id} was not found.");
                return -1;
            }

            movieDb = _mapper.Map(movieCreationDTO, movieDb);
            
            if (movieCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await movieCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(movieCreationDTO.Picture.FileName);
                    movieDb.Picture = 
                        await _fileStorageService.EditFile(content, extension, _containerName,
                                                            movieDb.Picture,
                                                            movieCreationDTO.Picture.ContentType);
                }
            }

            if (movieCreationDTO.BannerImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await movieCreationDTO.BannerImage.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(movieCreationDTO.BannerImage.FileName);
                    movieDb.BannerImage = 
                        await _fileStorageService.EditFile(content, extension, _containerName,
                                                            movieDb.BannerImage,
                                                            movieCreationDTO.BannerImage.ContentType);
                }
            }
            
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"
                                    DELETE FROM MoviesCasts WHERE MovieId = {movieDb.Id};
                                    DELETE FROM MoviePerson WHERE MovieId = {movieDb.Id};
                                    DELETE FROM CountryMovie WHERE MovieId = {movieDb.Id};
                                    DELETE FROM GenreMovie WHERE MovieId = {movieDb.Id};
                                    ");
            
            this.AnnotateCastsOrder(movieDb);
            await AddCategoryToPerson(movieDb);
            await SetMovieDirectorsGenresCastsListAsync(movieDb, movieCreationDTO);

            try
            {
                await this.SaveChangesAsync();
                _logger.LogInfo($"Movie with ID {id} was updated successfully.");
                await SetMovieRatingsAsync(movieDb);
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogWarn($"Failed to update movie with ID {id}. Exception: {ex}");
                return 0;
            }
        }

        public async Task<int> DeleteMovieAsync(int id)
        {
            var exists = await _dbContext.Movies.AnyAsync(m => m.Id == id);
            if (!exists)
            {
                _logger.LogWarn($"Movie with id {id} was not found.");
                return -1;
            }

            _dbContext.Remove(new Movie() {Id = id});
            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Movie with ID {id} was removed successfully.");
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogWarn($"Failed to remove movie with ID {id}. Exception: {ex}");
                return 0;
            }
        }

        public void AnnotateCastsOrder(Movie movie)
        {
            var movieCasts = movie.Casts.ToList();
            if (movieCasts != null)
            {
                for (int i = 0; i < movie.Casts.Count; i++)
                {
                    movieCasts[i].Order = i;
                }
            }
        }

        public async Task<int> CheckImdbIdAsync(string imdbId)
        {
            var exists = await _dbContext.Movies.AnyAsync(m => m.ImdbId == imdbId);
            if (exists)
            {
                _logger.LogWarn($"Imdb Id \"{imdbId}\" already exists.");
                return 1;
            }
            
            return 0;   
        }

        public async Task<int> AddUserCommentAsync(CommentCreationDTO commentCreationDTO)
        {
            var user = await _accountsService.GetCurrentUserAsync();
            commentCreationDTO.UserId = user.Id;
            commentCreationDTO.Type = 1;
            
            return await _commentService.SaveCommentAsync(commentCreationDTO);
        }

        public async Task<int> DeleteUserCommentAsync(int id) =>
            await _commentService.DeleteCommentAsync(id);
        
        public async Task<int> SaveUserMovieRatingAsync(MovieRatingDTO movieRatingDTO)
        {
            movieRatingDTO.UserId = await _accountsService.GetCurrentUserIdAsync();
            return await _ratingService.SaveMovieRatingAsync(movieRatingDTO);
        }

        public async Task<int> SaveUserFavoriteMoviesAsync(AddUserFavoriteMovieDTO addUserFavoriteMovieDTO)
        {
            addUserFavoriteMovieDTO.UserId = await _accountsService.GetCurrentUserIdAsync();
            return await _userFavoriteService.SaveUserFavoriteMovieAsync(addUserFavoriteMovieDTO);
        }
        
        private async Task<List<Genre>> ListGenres(MovieCreationDTO movieCreationDTO)
        {
            if (movieCreationDTO.GenresId == null)
                return null;

            var result = new List<Genre>();
            var genres = await _dbContext.Genres.ToListAsync();
            foreach (var id in movieCreationDTO.GenresId)
            {
                result.Add(genres.FirstOrDefault(x => x.Id == id));
            }
            return result;
        }

        private async Task<List<Person>> ListDirectors(MovieCreationDTO movieCreationDTO)
        {
            if (movieCreationDTO.DirectorsId == null)
                return null;

            var result = new List<Person>();
            foreach (var id in movieCreationDTO.DirectorsId)
            {
                result.Add(await _dbContext.People.FirstOrDefaultAsync(x => x.Id == id));
            }
            return result;
        }

        private async Task<List<Country>> ListCountries(MovieCreationDTO movieCreationDTO)
        {
            if (movieCreationDTO.CountriesId == null)
                return null;

            var result = new List<Country>();
            foreach (var id in movieCreationDTO.CountriesId)
            {
                result.Add(await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == id));
            }
            return result;
        }

        private async Task AddCategoryToPerson(Movie movie)
        {
            foreach (var director in movie.Directors)
            {
                var directorDb = await _dbContext.People.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == director.Id);
                if (!directorDb.Categories.Any(x => x.Id == 2))
                {
                    await _peopleService.AddCategoryToPersonAsync(directorDb, 2);
                }
            }

            foreach (var castId in movie.Casts.Select(x => x.PersonId))
            {
                var cast = await _dbContext.People.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == castId);
                if (!cast.Categories.Any(x => x.Id == 1))
                {
                    await _peopleService.AddCategoryToPersonAsync(cast, 1);
                }
            }
        }

        public async Task SetMovieRatingsAsync(Movie movie)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://www.imdb.com/title/" + movie.ImdbId);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarn($"Failed to get Ratings for movie {movie.Id} with ImdbId \"{movie.ImdbId}\".");
                    return;
                }
                var pageContents = await response.Content.ReadAsStringAsync();
                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(pageContents);
                movie.ImdbRate = pageDocument.DocumentNode.SelectSingleNode("//strong/span[1]").InnerText;
                movie.ImdbRatesCount = pageDocument.DocumentNode.SelectSingleNode("//span[@class='small']").InnerText;
                _logger.LogInfo($"Successfully saved Ratings for movie {movie.Id} with ImdbId \"{movie.ImdbId}\"");
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"SetMovieRatingsAsync thrown an exception: {ex}");
            }
            
        }

        public async Task SetMovieDirectorsGenresCastsListAsync(Movie movie, MovieCreationDTO movieCreationDTO)
        {
            movie.Genres = await ListGenres(movieCreationDTO);
            movie.Directors = await ListDirectors(movieCreationDTO);
            movie.Countries = await ListCountries(movieCreationDTO);
        }
    }
}