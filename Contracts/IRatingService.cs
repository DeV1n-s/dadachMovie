using System.Threading.Tasks;
using dadachMovie.DTOs;

namespace dadachMovie.Contracts
{
    public interface IRatingService
    {
        Task<int> SaveMovieRatingAsync(MovieRatingDTO movieRatingDTO);
        Task<int> SaveSerieRatingAsync(SerieRatingDTO serieRatingDTO);
    }
}