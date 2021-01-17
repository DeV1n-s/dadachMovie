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
        Task<Paging<MovieDetailsDTO>> GetCastMoviesListAsync(int id, GridifyQuery gridifyQuery);
        Task<Paging<MovieDetailsDTO>> GetDirectorMoviesListAsync(int id, GridifyQuery gridifyQuery);
        Task<PersonDTO> AddPersonAsync(PersonCreationDTO personCreationDTO);
        Task<int> UpdatePersonAsync(int id, PersonCreationDTO personCreationDTO);
        Task<int> DeletePersonAsync(int id);
    }
}