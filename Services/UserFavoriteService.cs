using System;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class UserFavoriteService : IUserFavoriteService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public UserFavoriteService(AppDbContext dbContext,
                                        IMapper mapper,
                                        ILoggerService logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> SaveUserFavoriteMovieAsync(AddUserFavoriteMovieDTO addUserFavoriteMovieDTO)
        {
            var movie = await _dbContext.Movies.AsTracking()
                                            .FirstOrDefaultAsync(m => m.Id == addUserFavoriteMovieDTO.MovieId);
            if (movie == null)
                return -2;
            
            var user = await _dbContext.Users.AsTracking()
                                            .Include(x => x.FavoriteMovies)
                                            .FirstOrDefaultAsync(u => u.Id == addUserFavoriteMovieDTO.UserId);
            if (user == null)
                return -3;
            
            if (user.FavoriteMovies.Contains(movie))
                return 0;
            
            user.FavoriteMovies.Add(movie);

            try
            {
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (System.Exception ex)
            {
                _logger.LogWarn($"Failed to SaveUserFavoriteMoviesAsync. Exception: {ex}");
                return -1;
            }
        }

        public async Task<int> SaveUserFavoriteSerieAsync(AddUserFavoriteSerieDTO addUserFavoriteSerieDTO)
        {
            var serie = await _dbContext.Series.AsTracking()
                                            .FirstOrDefaultAsync(m => m.Id == addUserFavoriteSerieDTO.SerieId);
            if (serie == null)
                return -2;
            
            var user = await _dbContext.Users.AsTracking()
                                            .Include(x => x.FavoriteSeries)
                                            .FirstOrDefaultAsync(u => u.Id == addUserFavoriteSerieDTO.UserId);
            if (user == null)
                return -3;

            if (user.FavoriteSeries.Contains(serie))
                return 0;
            
            user.FavoriteSeries.Add(serie);

            try
            {
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (System.Exception ex)
            {
                _logger.LogWarn($"Failed to SaveUserFavoriteSeriesAsync. Exception: {ex}");
                return -1;
            }
        }
    }
}