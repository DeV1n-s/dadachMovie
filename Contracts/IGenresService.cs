using System.Collections.Generic;
using System.Threading.Tasks;
using dadachMovie.DTOs;

namespace dadachMovie.Contracts
{
    public interface IGenresService : IBaseService
    {
        Task<List<GenreDTO>> GetGenresListAsync();
        Task<GenreDTO> GetGenreByIdAsync(int id);
        Task<GenreDTO> AddGenreAsync(GenreCreationDTO genreCreationDTO);
        Task<bool> UpdateGenreAsync(int id, GenreCreationDTO genreCreationDTO);
        Task<bool> DeleteGenreAsync(int id);
    }
}