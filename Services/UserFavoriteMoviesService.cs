using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class UserFavoriteMoviesService : IUserFavoriteMoviesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAccountsService _accountsService;

        public UserFavoriteMoviesService(AppDbContext dbContext,
                                        IMapper mapper,
                                        IAccountsService accountsService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _accountsService = accountsService;
        }
        public async Task<int> SaveUserFavoriteMovies(UserFavoriteMoviesDTO userFavoriteMoviesDTO)
        {
            var movie = await _dbContext.Movies.AsTracking()
                                            .FirstOrDefaultAsync(m => m.Id == userFavoriteMoviesDTO.FavoriteMoviesId);
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
                throw ex;
            }
        }
    }
}