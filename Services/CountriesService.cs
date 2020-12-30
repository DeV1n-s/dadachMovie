using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using dadachMovie.Helpers;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class CountriesService : BaseService, ICountriesService
    {
        private readonly AppDbContext _dbContext;

        public CountriesService(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Country> GetCountriesQueryable() =>
            _dbContext.Countries.AsNoTracking().OrderBy(c => c.Id).AsQueryable();

        public async Task<List<Country>> GetCountriesListAsync(PaginationDTO paginationDTO) =>
            await this.GetCountriesQueryable().Paginate(paginationDTO).ToListAsync();

        public async Task<Country> GetCountryByIdAsync(int id) =>
            await _dbContext.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }
}