using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IMoviesService : IBaseService
    {
        Task<Paging<MovieDetailsDTO>> GetMoviesDetailsPagingAsync(GridifyQuery gridifyQuery);
        Task<MovieDetailsDTO> GetMovieByIdAsync(int id);
        Task<IndexMoviePageDTO> GetTopMoviesAsync(int amount);
        IQueryable<MovieDetailsDTO> GetMoviesDetailsQueryable();
        IQueryable<Movie> GetMoviesQueryable();
        Task<MovieDTO> AddMovieAsync(MovieCreationDTO movieCreationDTO);
        Task<bool> UpdateMovieAsync(int id, MovieCreationDTO movieCreationDTO);
        //Task<bool> PatchMovieAsync(int id, JsonPatchDocument<MoviePatchDTO> patchDocument);
        Task<bool> DeleteMovieAsync(int id);

        void AnnotateCastsOrder(Movie movie);
    }
}