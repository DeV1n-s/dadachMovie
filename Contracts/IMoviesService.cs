using System.Linq;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IMoviesService : IBaseService
    {
        Task<Paging<MovieDTO>> GetMoviesDetailsPagingAsync(GridifyQuery gridifyQuery);
        Task<MovieDetailsDTO> GetMovieByIdAsync(int id);
        Task<Paging<MovieDTO>> GetUpcomingReleasesAsync(GridifyQuery gridifyQuery);
        Task<Paging<MovieDTO>> GetInTheatersAsync(GridifyQuery gridifyQuery);
        IQueryable<MovieDetailsDTO> GetMoviesDetailsQueryable();
        IQueryable<Movie> GetMoviesQueryable();
        Task<MovieDTO> AddMovieAsync(MovieCreationDTO movieCreationDTO);
        Task<int> UpdateMovieAsync(int id, MovieCreationDTO movieCreationDTO);
        Task<int> DeleteMovieAsync(int id);
        Task<int> CheckImdbIdAsync(string imdbId);
        Task<int> AddUserCommentAsync(CommentCreationDTO commentCreationDTO);
        Task<int> DeleteUserCommentAsync(int id);

        void AnnotateCastsOrder(Movie movie);
    }
}