using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly AppDbContext dbContext;

        public CountriesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Country>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = dbContext.Countries.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            var countries = await queryable.Paginate(paginationDTO)
                                    .OrderBy(c => c.Id)
                                    .ToListAsync();
            return countries;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Country>> GetById(int id)
        {
            var country = await dbContext.Countries.SingleOrDefaultAsync(c => c.Id == id);
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