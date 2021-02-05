using System.Threading.Tasks;
using dadachMovie.DTOs;

namespace dadachMovie.Contracts
{
    public interface IUserFavoriteService
    {
        Task<int> SaveUserFavoriteMovieAsync(AddUserFavoriteMovieDTO addUserFavoriteMovieDTO);
        Task<int> SaveUserFavoriteSerieAsync(AddUserFavoriteSerieDTO addUserFavoriteSerieDTO);
    }
}