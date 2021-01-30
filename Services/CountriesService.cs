using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class CountriesService : BaseService, ICountriesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public CountriesService(AppDbContext dbContext,
                                IMapper mapper,
                                ILoggerService logger)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IQueryable<CountryDTO> GetCountriesQueryable()
        {
            var countries = _dbContext.Countries.AsNoTracking().OrderBy(c => c.Id).AsQueryable();
            return _mapper.Map<IQueryable<CountryDTO>>(countries);
        }

        public async Task<Paging<CountryDTO>> GetCountriesListAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Countries.AsNoTracking().GridifyQueryableAsync(gridifyQuery,null);
            return new Paging<CountryDTO> {Items = queryable.Query.ProjectTo<CountryDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
        }

        public async Task<CountryDTO> GetCountryByIdAsync(int id)
        {
            var countries = await _dbContext.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (countries == null)
                _logger.LogWarn($"Country with ID {id} was not found.");
            return _mapper.Map<CountryDTO>(countries);
        }  
    }
}