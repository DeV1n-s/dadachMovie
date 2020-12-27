using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;

namespace dadachMovie.Contracts
{
    public interface ICountriesService
    {
        Task<List<Country>> GetCountriesListAsync(PaginationDTO paginationDTO);
        IQueryable<Country> GetCountriesQueryable();
        Task<Country> GetCountryByIdAsync(int id);

    }
}