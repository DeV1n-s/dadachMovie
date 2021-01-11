using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using Gridify;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly ICountriesService _countriesService;

        public CountriesController(AppDbContext dbContext,
                                ICountriesService countriesService)
        {
            _dbContext = dbContext;
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<ActionResult<Paging<CountryDTO>>> Get([FromQuery] GridifyQuery gridifyQuery) =>
            await _countriesService.GetCountriesListAsync(gridifyQuery);

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CountryDTO>> GetById(int id)
        {
            var country = await _countriesService.GetCountryByIdAsync(id);
            if (country == null)
                return NotFound();

            return country;
        }
    }
}