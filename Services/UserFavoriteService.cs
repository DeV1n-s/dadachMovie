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
        public async Task<int> SaveUserFavoriteMoviesAsync(UserFavoriteMoviesDTO userFavoriteMoviesDTO)
        {
            var movie = await _dbContext.Movies.AsTracking()
                                            .FirstOrDefaultAsync(m => m.Id == userFavoriteMoviesDTO.MovieId);
            if (movie == null)
                return -2;
            
            var user = await _dbContext.Users.AsTracking()
                                            .Include(x => x.FavoriteMovies)
                                            .FirstOrDefaultAsync(u => u.Id == userFavoriteMoviesDTO.UserId);
            if (user == null)
                return -3;
            
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

        public async Task<int> SaveUserFavoriteSeriesAsync(UserFavoriteSeriesDTO userFavoriteSeriesDTO)
        {
            var serie = await _dbContext.Series.AsTracking()
                                            .FirstOrDefaultAsync(m => m.Id == userFavoriteSeriesDTO.SerieId);
            if (serie == null)
                return -2;
            
            var user = await _dbContext.Users.AsTracking()
                                            .Include(x => x.FavoriteSeries)
                                            .FirstOrDefaultAsync(u => u.Id == userFavoriteSeriesDTO.UserId);
            if (user == null)
                return -3;
            
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