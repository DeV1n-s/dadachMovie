using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using dadachMovie.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<List<Country>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var countriesQueryable = _countriesService.GetCountriesQueryable();
            if( countriesQueryable == null)
                return UnprocessableEntity("Failed to get CountriesList from service.");

            await HttpContext.InsertPaginationParametersInResponse(countriesQueryable, paginationDTO.RecordsPerPage);
            return await countriesQueryable.Paginate(paginationDTO).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Country>> GetById(int id)
        {
            var country = await _countriesService.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // [HttpGet("filter")]
        // public async Task<ActionResult> Filter([FromQuery] CountryFilterDTO countryFilterDTO)
    }
}