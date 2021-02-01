using System.Threading.Tasks;
using dadachMovie.DTOs;

namespace dadachMovie.Contracts
{
    public interface IUserFavoriteService
    {
        Task<int> SaveUserFavoriteMoviesAsync(UserFavoriteMoviesDTO userFavoriteMoviesDTO);
        Task<int> SaveUserFavoriteSeriesAsync(UserFavoriteSeriesDTO userFavoriteSeriesDTO);
    }
}