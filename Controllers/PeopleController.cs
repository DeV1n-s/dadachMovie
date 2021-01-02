using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using Gridify;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public PeopleController(IPeopleService peopleService,
                                IMapper mapper,
                                AppDbContext dbContext)
        {
            _peopleService = peopleService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<Paging<PersonDTO>>> Get([FromQuery] GridifyQuery gridifyQuery) =>
            await _peopleService.GetPeoplePagingAsync(gridifyQuery);

        [HttpGet("{id}", Name = "getPerson")]
        public async Task<ActionResult<PersonDTO>> GetById(int id)
        {
            var person = await _peopleService.GetPersonByIdAsync(id);
            if (person == null)
                return NotFound();

            return person;
        }

        [HttpGet("{id:int}/CastMovies")]
        public async Task<ActionResult<List<MovieDetailsDTO>>> GetCastMovies(int id)
        {
            var person = await _peopleService.GetPersonByIdAsync(id);
            if (person == null)
                return NotFound();

            return await _peopleService.GetCastMoviesListAsync(id);
        }

        [HttpGet("{id:int}/DirectorMovies")]
        public async Task<ActionResult<List<MovieDetailsDTO>>> GetDirectorMovies(int id)
        {
            var person = await _peopleService.GetPersonByIdAsync(id);
            if (person == null)
                return NotFound();

            return await _peopleService.GetDirectorMoviesListAsync(id);
        }
        
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Post([FromForm] PersonCreationDTO personCreationDTO)
        {
            var personDTO = await _peopleService.AddPersonAsync(personCreationDTO);
            return new CreatedAtRouteResult("getPerson", new { id = personDTO.Id }, personDTO);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(int id, [FromForm] PersonCreationDTO personCreationDTO)
        {
            if (!await _peopleService.UpdatePersonAsync(id, personCreationDTO))
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<PersonPatchDTO> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            var entityFromDb = await _peopleService.GetPersonByIdAsync(id);
            if (entityFromDb == null)
                return NotFound();

            var entityDTO = _mapper.Map<PersonPatchDTO>(entityFromDb);

            patchDocument.ApplyTo(entityDTO, ModelState);

            var isValid = TryValidateModel(entityDTO);
            if (!isValid)
                return BadRequest(ModelState);

            _mapper.Map(entityDTO, entityFromDb);
            await _peopleService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!await _peopleService.DeletePersonAsync(id))
                return NotFound();

            return NoContent();
        }
    }
}