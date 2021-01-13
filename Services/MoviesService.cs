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
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class MoviesService : BaseService, IMoviesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private readonly string _containerName = "movies";

        public MoviesService(AppDbContext dbContext,
                            IMapper mapper,
                            IFileStorageService fileStorageService)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }
        public async Task<Paging<MovieDetailsDTO>> GetMoviesDetailsPagingAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Movies.GridifyQueryableAsync(gridifyQuery,null);
            return new Paging<MovieDetailsDTO> {Items = queryable.Query.ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider).ToList(),
                                                TotalItems = queryable.TotalItems};
        }

        public async Task<MovieDetailsDTO> GetMovieByIdAsync(int id) =>
            await _dbContext.Movies.AsNoTracking()
                                .ProjectTo<MovieDetailsDTO>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(m => m.Id == id);
        public async Task<IndexMoviePageDTO> GetTopMoviesAsync(int amount)
        {
            if (amount == 0)
                amount = 5;

            var today = DateTime.Today;
            var upcomingReleases = await _dbContext.Movies
                .AsNoTracking()
                .Where(m => m.ReleaseDate > today)
                .OrderByDescending(m => m.ReleaseDate)
                .Take(amount)
                .ToListAsync();

            var inTheaters = await _dbContext.Movies
                .AsNoTracking()
                .Where(m => m.InTheaters)
                .OrderByDescending(m => m.Id)
                .Take(amount)
                .ToListAsync();

            var result = new IndexMoviePageDTO();
            result.InTheaters = _mapper.Map<List<MovieDTO>>(inTheaters);
            result.UpcomingReleases = _mapper.Map<List<MovieDTO>>(upcomingReleases);

            return result;
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

            movie.CreatedAt = DateTimeOffset.Now;
            this.AnnotateCastsOrder(movie);

            _dbContext.Add(movie);
            await this.SaveChangesAsync();
            
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task<int> UpdateMovieAsync(int id, MovieCreationDTO movieCreationDTO)
        {
            var movieDb = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movieDb == null)
                return -1;

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
            
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"
                                    DELETE FROM MoviesActors WHERE MovieId = {movieDb.Id}; 
                                    DELETE FROM MoviesGenres WHERE MovieId = {movieDb.Id}; 
                                    DELETE FROM MoviesDirectors WHERE MovieId = {movieDb.Id};
                                    ");
            
            this.AnnotateCastsOrder(movieDb);
            try
            {
                await this.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> DeleteMovieAsync(int id)
        {
            var exists = await _dbContext.Movies.AnyAsync(m => m.Id == id);
            if (!exists)
                return -1;

            _dbContext.Remove(new Movie() {Id = id});
            try
            {
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public void AnnotateCastsOrder(Movie movie)
        {
            if (movie.Casts != null)
            {
                for (int i = 0; i < movie.Casts.Count; i++)
                {
                    movie.Casts[i].Order = i;
                }
            }
        }
    }
}