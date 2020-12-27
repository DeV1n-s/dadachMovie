using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using dadachMovie.Helpers;
using dadachMovie.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly IMapper _mapper;

        public PeopleController(IPeopleService peopleService,
                                IMapper mapper)
        {
            _peopleService = peopleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var peopleQueryable = _peopleService.GetPeopleQueryable();
            if( peopleQueryable == null)
                return UnprocessableEntity("Failed to get GenresList from service.");

            await HttpContext.InsertPaginationParametersInResponse(peopleQueryable, paginationDTO.RecordsPerPage);
            var people = await peopleQueryable.Paginate(paginationDTO)
                                        .ProjectTo<PersonDTO>(_mapper.ConfigurationProvider)
                                        .ToListAsync();

            return people;
        }

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

        [HttpGet("filter")]
        public async Task<ActionResult<List<PersonDTO>>> Filter([FromQuery] FilterPersonDTO filterPersonDTO)
        {
            var peopleQueryable = _peopleService.GetPeopleQueryable();

            if (!string.IsNullOrWhiteSpace(filterPersonDTO.Name))
                peopleQueryable = peopleQueryable.Where(p => p.Name.Contains(filterPersonDTO.Name));

            if (filterPersonDTO.IsCast)
                peopleQueryable = peopleQueryable.Where(p => p.IsCast);

            if (filterPersonDTO.IsDirector)
                peopleQueryable = peopleQueryable.Where(p => p.IsDirector);

            if (!string.IsNullOrWhiteSpace(filterPersonDTO.MinDateOfBirth.ToString()))
                peopleQueryable = peopleQueryable.Where(p => 
                                                    (p.DateOfBirth >= filterPersonDTO.MinDateOfBirth) && 
                                                    (p.DateOfBirth <= filterPersonDTO.MaxDateOfBirth));

            if (!string.IsNullOrWhiteSpace(filterPersonDTO.OrderingField))
            {
                try
                {
                    peopleQueryable = peopleQueryable
                        .OrderBy($"{filterPersonDTO.OrderingField} {(filterPersonDTO.AscendingOrder ? "ascending" : "descending")}");
                }
                catch
                { }
            }

            await HttpContext.InsertPaginationParametersInResponse(peopleQueryable, filterPersonDTO.RecordsPerPage);
            var people = await peopleQueryable.Paginate(filterPersonDTO.Pagination).ToListAsync();

            return _mapper.Map<List<PersonDTO>>(people);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PersonCreationDTO personCreationDTO)
        {
            var personDTO = await _peopleService.AddPersonAsync(personCreationDTO);
            return new CreatedAtRouteResult("getPerson", new { id = personDTO.Id }, personDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] PersonCreationDTO personCreationDTO)
        {
            if (!await _peopleService.UpdatePersonAsync(id, personCreationDTO))
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}")]
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
        public async Task<ActionResult> Delete(int id)
        {
            if (!await _peopleService.DeletePersonAsync(id))
                return NotFound();

            return NoContent();
        }
    }
}