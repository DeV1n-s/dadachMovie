using System.Threading.Tasks;
using dadachMovie.DTOs;

namespace dadachMovie.Contracts
{
    public interface IUserFavoriteMoviesService
    {
        Task<int> SaveUserFavoriteMovies(UserFavoriteMoviesDTO userFavoriteMoviesDTO);
    }
}