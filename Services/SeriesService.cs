using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;
using Gridify.EntityFramework;
using IMDbApiLib;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class SeriesService : BaseService, ISeriesService
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
        private readonly string _containerName = "series";
        private ApiLib _apiLib = new ApiLib("k_l3dksm3b");

        public SeriesService(AppDbContext dbContext,
                            IMapper mapper,
                            IFileStorageService fileStorageService,
                            ILoggerService logger,
                            ICommentService commentService,
                            IAccountsService accountsService,
                            IPeopleService peopleService,
                            IRatingService ratingService,
                            IUserFavoriteService userFavoriteService)
            :base(dbContext)
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
        public async Task<Paging<SerieDTO>> GetSeriesPagingAsync(int? genreId, GridifyQuery gridifyQuery)
        {
            var series = _dbContext.Series.AsNoTracking()
                                        .Include(x => x.Genres);
            
            var queryable = await series.GridifyQueryableAsync(gridifyQuery, null);

            if (genreId != null)
            {
                queryable = await series.Where(x => x.Genres.Any(x => x.Id == genreId))
                                        .GridifyQueryableAsync(gridifyQuery, null);
            }

            return new Paging<SerieDTO> {Items = queryable.Query.ProjectTo<SerieDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }

        public async Task<SerieDetailsDTO> GetSerieDetailsByIdAsync(int id) =>
            await _dbContext.Series.AsNoTracking()
                                .ProjectTo<SerieDetailsDTO>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(m => m.Id == id);
        
        public async Task<Serie> GetSerieByIdAsync(int id) =>
            await _dbContext.Series.AsNoTracking()
                                .FirstOrDefaultAsync(m => m.Id == id);
        
        public async Task<Paging<SerieDTO>> GetSeriesByGenreIdPagingAsync(int id, GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Series.AsNoTracking()
                                                .Include(x => x.Genres)
                                                .Where(x => x.Genres.Any(x => x.Id == id))
                                                .GridifyQueryableAsync(gridifyQuery,null);

            return new Paging<SerieDTO> {Items = queryable.Query.ProjectTo<SerieDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }
            
        public async Task<Paging<SerieDTO>> GetUpcomingReleasesAsync(GridifyQuery gridifyQuery)
        {
            var today = DateTime.Today;
            var queryable = await _dbContext.Series
                .AsNoTracking()
                .Where(x => x.StartDate > today)
                .GridifyQueryableAsync(gridifyQuery,null);

            return new Paging<SerieDTO> {Items = queryable.Query.ProjectTo<SerieDTO>(_mapper.ConfigurationProvider).ToList(),
                                                TotalItems = queryable.TotalItems};
        }

        public IQueryable<SerieDetailsDTO> GetSeriesDetailsQueryable() =>
            _dbContext.Series.AsNoTracking()
                            .ProjectTo<SerieDetailsDTO>(_mapper.ConfigurationProvider)
                            .AsQueryable();
        
        public IQueryable<Serie> GetSeriesQueryable() =>
            _dbContext.Series.AsNoTracking().AsQueryable();

        public async Task<SerieDTO> AddSerieAsync(SerieCreationDTO serieCreationDTO)
        {
            var serie = _mapper.Map<Serie>(serieCreationDTO);

            if (serieCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await serieCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(serieCreationDTO.Picture.FileName);
                    serie.Picture = 
                        await _fileStorageService.SaveFile(content, extension, _containerName,
                                                            serieCreationDTO.Picture.ContentType);
                }
            }

            if (serieCreationDTO.BannerImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await serieCreationDTO.BannerImage.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(serieCreationDTO.BannerImage.FileName);
                    serie.BannerImage = 
                        await _fileStorageService.SaveFile(content, extension, _containerName,
                                                            serieCreationDTO.BannerImage.ContentType);
                }
            }

            this.AnnotateCastsOrder(serie);
            await SetSerieDirectorsGenresCastsListAsync(serie, serieCreationDTO);
            await AddCategoryToPerson(serie);

            _dbContext.Add(serie);
            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Serie with ID {serie.Id} was added successfully.");
                await SetSerieRatingsAsync(serie);
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to add serie {serie.Id}. Exception: {ex}");
            }
            
            return _mapper.Map<SerieDTO>(serie);
        }

        public async Task<int> UpdateSerieAsync(int id, SerieCreationDTO serieCreationDTO)
        {
            var serie = await _dbContext.Series.FirstOrDefaultAsync(m => m.Id == id);
            if (serie == null)
            {
                _logger.LogWarn($"Serie with ID {id} was not found.");
                return -1;
            }

            serie = _mapper.Map(serieCreationDTO, serie);
            
            if (serieCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await serieCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(serieCreationDTO.Picture.FileName);
                    serie.Picture = 
                        await _fileStorageService.EditFile(content, extension, _containerName,
                                                            serie.Picture,
                                                            serieCreationDTO.Picture.ContentType);
                }
            }

            if (serieCreationDTO.BannerImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await serieCreationDTO.BannerImage.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(serieCreationDTO.BannerImage.FileName);
                    serie.BannerImage = 
                        await _fileStorageService.EditFile(content, extension, _containerName,
                                                            serie.BannerImage,
                                                            serieCreationDTO.BannerImage.ContentType);
                }
            }
            
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"
                                    DELETE FROM SeriesCasts WHERE SerieId = {serie.Id};
                                    DELETE FROM SeriePerson WHERE SerieId = {serie.Id};
                                    DELETE FROM CountrySerie WHERE SerieId = {serie.Id};
                                    DELETE FROM GenreSerie WHERE SerieId = {serie.Id};
                                    ");
            
            this.AnnotateCastsOrder(serie);
            await AddCategoryToPerson(serie);
            await SetSerieRatingsAsync(serie);
            await SetSerieDirectorsGenresCastsListAsync(serie, serieCreationDTO);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Serie with ID {id} was updated successfully.");
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogWarn($"Failed to update serie with ID {id}. Exception: {ex}");
                return 0;
            }
        }

        public async Task<int> DeleteSerieAsync(int id)
        {
            var exists = await _dbContext.Series.AnyAsync(m => m.Id == id);
            if (!exists)
            {
                _logger.LogWarn($"Serie with id {id} was not found.");
                return -1;
            }

            _dbContext.Remove(new Serie() {Id = id});
            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Serie with ID {id} was removed successfully.");
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogWarn($"Failed to remove serie with ID {id}. Exception: {ex}");
                return 0;
            }
        }

        public void AnnotateCastsOrder(Serie serie)
        {
            var serieCasts = serie.Casts.ToList();
            if (serieCasts != null)
            {
                for (int i = 0; i < serie.Casts.Count; i++)
                {
                    serieCasts[i].Order = i;
                }
            }
        }

        public async Task<int> CheckImdbIdAsync(string imdbId)
        {
            var exists = await _dbContext.Series.AnyAsync(m => m.ImdbId == imdbId);
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
            commentCreationDTO.Type = 2;
            
            return await _commentService.SaveCommentAsync(commentCreationDTO);
        }

        public async Task<int> DeleteUserCommentAsync(int id) =>
            await _commentService.DeleteCommentAsync(id);
        
        public async Task<int> SaveUserSerieRatingAsync(SerieRatingDTO serieRatingDTO)
        {
            serieRatingDTO.UserId = await _accountsService.GetCurrentUserIdAsync();
            return await _ratingService.SaveSerieRatingAsync(serieRatingDTO);
        }
        
        public async Task<int> SaveUserFavoriteSeriesAsync(UserFavoriteSeriesDTO userFavoriteSeriesDTO)
        {
            userFavoriteSeriesDTO.UserId = await _accountsService.GetCurrentUserIdAsync();
            return await _userFavoriteService.SaveUserFavoriteSeriesAsync(userFavoriteSeriesDTO);
        }
        
        private async Task<List<Genre>> ListGenres(SerieCreationDTO serieCreationDTO)
        {
            if (serieCreationDTO.GenresId == null)
                return null;

            var result = new List<Genre>();
            var genres = await _dbContext.Genres.ToListAsync();
            foreach (var id in serieCreationDTO.GenresId)
            {
                result.Add(genres.FirstOrDefault(x => x.Id == id));
            }
            return result;
        }

        private async Task<List<Person>> ListDirectors(SerieCreationDTO serieCreationDTO)
        {
            if (serieCreationDTO.DirectorsId == null)
                return null;

            var result = new List<Person>();
            foreach (var id in serieCreationDTO.DirectorsId)
            {
                result.Add(await _dbContext.People.FirstOrDefaultAsync(x => x.Id == id));
            }
            return result;
        }

        private async Task<List<Country>> ListCountries(SerieCreationDTO serieCreationDTO)
        {
            if (serieCreationDTO.CountriesId == null)
                return null;

            var result = new List<Country>();
            foreach (var id in serieCreationDTO.CountriesId)
            {
                result.Add(await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == id));
            }
            return result;
        }

        private async Task AddCategoryToPerson(Serie serie)
        {
            foreach (var director in serie.Directors)
            {
                var directorDb = await _dbContext.People.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == director.Id);
                if (!directorDb.Categories.Any(x => x.Id == 2))
                {
                    await _peopleService.AddCategoryToPersonAsync(directorDb, 2);
                }
            }

            foreach (var castId in serie.Casts.Select(x => x.PersonId))
            {
                var cast = await _dbContext.People.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == castId);
                if (!cast.Categories.Any(x => x.Id == 1))
                {
                    await _peopleService.AddCategoryToPersonAsync(cast, 1);
                }
            }
        }

        public async Task SetSerieRatingsAsync(Serie serie)
        {
            try
            {
                var imdbRates = await _apiLib.UserRatingAsync(serie.ImdbId);
                serie.ImdbRate = imdbRates.TotalRating;
                serie.ImdbRatesCount = imdbRates.TotalRatingVotes;
                _logger.LogInfo($"Successfully saved UserRating for serie {serie.Id} with ImdbId \"{serie.ImdbId}\"");
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to get UserRating for serie {serie.Id} with ImdbId \"{serie.ImdbId}\". Exception: {ex}");
            }
            
            try
            {
                var otherRates = await _apiLib.RatingsAsync(serie.ImdbId);
                serie.MetacriticRate = otherRates.Metacritic;
                _logger.LogInfo($"Successfully saved Ratings for serie {serie.Id} with ImdbId \"{serie.ImdbId}\"");
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to get Ratings for serie {serie.Id} with ImdbId \"{serie.ImdbId}\". Exception: {ex}");
            }
            
        }

        public async Task SetSerieDirectorsGenresCastsListAsync(Serie serie, SerieCreationDTO serieCreationDTO)
        {
            serie.Genres = await ListGenres(serieCreationDTO);
            serie.Directors = await ListDirectors(serieCreationDTO);
            serie.Countries = await ListCountries(serieCreationDTO);
        }
    }
}