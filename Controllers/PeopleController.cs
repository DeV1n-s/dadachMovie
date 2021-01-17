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
        public async Task<ActionResult<Paging<MovieDetailsDTO>>> GetCastMovies(int id,[FromQuery] GridifyQuery gridifyQuery)
        {
            var person = await _peopleService.GetPersonByIdAsync(id);
            if (person == null)
                return NotFound();

            return await _peopleService.GetCastMoviesListAsync(id, gridifyQuery);
        }

        [HttpGet("{id:int}/DirectorMovies")]
        public async Task<ActionResult<Paging<MovieDetailsDTO>>> GetDirectorMovies(int id, [FromQuery] GridifyQuery gridifyQuery)
        {
            var person = await _peopleService.GetPersonByIdAsync(id);
            if (person == null)
                return NotFound();

            return await _peopleService.GetDirectorMoviesListAsync(id, gridifyQuery);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post([FromForm] PersonCreationDTO personCreationDTO)
        {
            var personDTO = await _peopleService.AddPersonAsync(personCreationDTO);
            return new CreatedAtRouteResult("getPerson", new { id = personDTO.Id }, personDTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(int id, [FromForm] PersonCreationDTO personCreationDTO)
        {
            var result = await _peopleService.UpdatePersonAsync(id, personCreationDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _peopleService.DeletePersonAsync(id);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }
    }
}