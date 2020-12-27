using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace dadachMovie.Contracts
{
    public interface IMoviesService : IBaseService
    {
        Task<List<MovieDetailsDTO>> GetMoviesListAsync(PaginationDTO paginationDTO);
        Task<MovieDetailsDTO> GetMovieByIdAsync(int id);
        Task<IndexMoviePageDTO> GetTopMoviesAsync(int amount);
        IQueryable<MovieDetailsDTO> GetMoviesDetailsQueryable();
        public IQueryable<Movie> GetMoviesQueryable();
        //IQueryable<Movie> FilterMoviesListAsync(FilterMoviesDTO filterMoviesDTO);
        Task<MovieDTO> AddMovieAsync(MovieCreationDTO movieCreationDTO);
        Task<bool> UpdateMovieAsync(int id, MovieCreationDTO movieCreationDTO);
        //Task<bool> PatchMovieAsync(int id, JsonPatchDocument<MoviePatchDTO> patchDocument);
        Task<bool> DeleteMovieAsync(int id);

        void AnnotateCastsOrder(Movie movie);
    }
}