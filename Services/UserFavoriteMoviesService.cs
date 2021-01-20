using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class UserFavoriteMoviesService : IUserFavoriteMoviesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private readonly IAccountsService _accountsService;

        public UserFavoriteMoviesService(AppDbContext dbContext,
                                        IMapper mapper,
                                        ILoggerService logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> SaveUserFavoriteMovies(UserFavoriteMoviesDTO userFavoriteMoviesDTO)
        {
            var movie = await _dbContext.Movies.AsTracking()
                                            .FirstOrDefaultAsync(m => m.Id == userFavoriteMoviesDTO.MovieId);
            if (movie == null)
            {
                return -2;
            }
            
            var user = await _dbContext.Users.AsTracking()
                                            .FirstOrDefaultAsync(u => u.Id == userFavoriteMoviesDTO.UserId);
            if (user == null)
            {
                return -3;
            }
            
            user.FavoriteMovies.Add(movie);

            try
            {
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (System.Exception ex)
            {
                _logger.LogWarn($"Failed to save changes on \"user.FavoriteMovies.Add(movie)\". Exception: {ex}");
                return -1;
            }
        }
    }
}