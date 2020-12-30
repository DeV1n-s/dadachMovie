using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;

namespace dadachMovie.Contracts
{
    public interface ICountriesService : IBaseService
    {
        Task<Paging<CountryDTO>> GetCountriesListAsync(GridifyQuery gridifyQuery);
        IQueryable<CountryDTO> GetCountriesQueryable();
        Task<CountryDTO> GetCountryByIdAsync(int id);
    }
}