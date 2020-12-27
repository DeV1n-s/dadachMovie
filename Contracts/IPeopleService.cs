using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;

namespace dadachMovie.Contracts
{
    public interface IPeopleService : IBaseService
    {
        Task<List<PersonDTO>> GetPeopleListAsync(PaginationDTO paginationDTO);
        Task<PersonDTO> GetPersonByIdAsync(int id);
        IQueryable<Person> GetPeopleQueryable();
        Task<List<MovieDetailsDTO>> GetCastMoviesListAsync(int id);
        Task<List<MovieDetailsDTO>> GetDirectorMoviesListAsync(int id);
        Task<PersonDTO> AddPersonAsync(PersonCreationDTO personCreationDTO);
        Task<bool> UpdatePersonAsync(int id, PersonCreationDTO personCreationDTO);
        Task<bool> DeletePersonAsync(int id);
    }
}