using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface IPeopleService : IBaseService
    {
        Task<Paging<PersonDTO>> GetPeoplePagingAsync(GridifyQuery gridifyQuery);
        Task<PersonDTO> GetPersonByIdAsync(int id);
        IQueryable<Person> GetPeopleQueryable();
        Task<List<MovieDetailsDTO>> GetCastMoviesListAsync(int id);
        Task<List<MovieDetailsDTO>> GetDirectorMoviesListAsync(int id);
        Task<PersonDTO> AddPersonAsync(PersonCreationDTO personCreationDTO);
        Task<bool> UpdatePersonAsync(int id, PersonCreationDTO personCreationDTO);
        Task<bool> DeletePersonAsync(int id);
    }
}