using System.Threading.Tasks;
using dadachMovie.DTOs;

namespace dadachMovie.Contracts
{
    public interface IRatingService
    {
        Task<int> SaveRatingAsync(MovieRatingDTO movieRatingDTO);
    }
}