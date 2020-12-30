using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IGenresService : IBaseService
    {
        Task<Paging<GenreDTO>> GetGenresPagingAsync(GridifyQuery gridifyQuery);
        Task<GenreDTO> GetGenreByIdAsync(int id);
        Task<GenreDTO> AddGenreAsync(GenreCreationDTO genreCreationDTO);
        Task<bool> UpdateGenreAsync(int id, GenreCreationDTO genreCreationDTO);
        Task<bool> DeleteGenreAsync(int id);
    }
}