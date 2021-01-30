using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IGenresService : IBaseService
    {
        Task<Paging<GenreDetailsDTO>> GetGenresDetailsPagingAsync(GridifyQuery gridifyQuery);
        Task<GenreDetailsDTO> GetGenreDetailsByIdAsync(int id);
        Task<GenreDTO> AddGenreAsync(GenreCreationDTO genreCreationDTO);
        Task<int> UpdateGenreAsync(int id, GenreCreationDTO genreCreationDTO);
        Task<int> DeleteGenreAsync(int id);
    }
}