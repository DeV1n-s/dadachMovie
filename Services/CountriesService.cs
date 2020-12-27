using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using dadachMovie.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly AppDbContext _dbContext;

        public CountriesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Country> GetCountriesQueryable() =>
            _dbContext.Countries.AsNoTracking().OrderBy(c => c.Id).AsQueryable();

        public async Task<List<Country>> GetCountriesListAsync(PaginationDTO paginationDTO)
        {
            var queryable = _dbContext.Countries.AsQueryable();
            return await queryable.AsNoTracking()
                                .Paginate(paginationDTO)
                                .OrderBy(c => c.Id)
                                .ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
            => await _dbContext.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }
}