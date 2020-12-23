using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private readonly string containerName = "people";

        public PeopleController(AppDbContext dbContext, IMapper mapper, IFileStorageService fileStorageService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = dbContext.People.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            var people = await queryable.Paginate(paginationDTO).ProjectTo<PersonDTO>(mapper.ConfigurationProvider).ToListAsync();

            return people;
        }

        [HttpGet("{id}", Name = "getPerson")]
        public async Task<ActionResult<PersonDTO>> GetById(int id)
        {
            // var person = await dbContext.People.Include(x => x.Country)
            //                                 .ThenInclude(x => x.Country)
            //                                 .FirstOrDefaultAsync(p => p.Id == id);
            var person = await dbContext.People.ProjectTo<PersonDTO>(mapper.ConfigurationProvider)
                                            .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpGet("{id:int}/CastMovies")]
        public async Task<ActionResult<List<MovieDetailsDTO>>> GetCastMovies(int id)
        {
            
            var person = dbContext.People.Any(x => x.Id == id);
            if (!person)
            {
                return NotFound();
            }

            return await dbContext.Movies.ProjectTo<MovieDetailsDTO>(mapper.ConfigurationProvider)
                                        .Where(x => x.Casts.Any(x => x.PersonId == id)).ToListAsync();
        }

        [HttpGet("{id:int}/DirectorMovies")]
        public async Task<ActionResult<List<MovieDetailsDTO>>> GetDirectorMovies(int id)
        {
            
            var person = dbContext.People.Any(x => x.Id == id);
            if (!person)
            {
                return NotFound();
            }

            return await dbContext.Movies.ProjectTo<MovieDetailsDTO>(mapper.ConfigurationProvider)
                                        .Where(x => x.Directors.Any(x => x.PersonId == id)).ToListAsync();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<PersonDTO>>> Filter([FromQuery] FilterPersonDTO filterPersonDTO)
        {
            var peopleQueryable = dbContext.People.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterPersonDTO.Name))
            {
                peopleQueryable = peopleQueryable.Where(p => p.Name.Contains(filterPersonDTO.Name));
            }

            if (filterPersonDTO.IsCast)
            {
                peopleQueryable = peopleQueryable.Where(p => p.IsCast);
            }

            if (filterPersonDTO.IsDirector)
            {
                peopleQueryable = peopleQueryable.Where(p => p.IsDirector);
            }

            if (!string.IsNullOrWhiteSpace(filterPersonDTO.MinDateOfBirth.ToString()))
            {
                peopleQueryable = peopleQueryable.Where(p => 
                                                    (p.DateOfBirth >= filterPersonDTO.MinDateOfBirth) && 
                                                    (p.DateOfBirth <= filterPersonDTO.MaxDateOfBirth));
            }

            if (!string.IsNullOrWhiteSpace(filterPersonDTO.OrderingField))
            {
                try
                {
                    peopleQueryable = peopleQueryable
                        .OrderBy($"{filterPersonDTO.OrderingField} {(filterPersonDTO.AscendingOrder ? "ascending" : "descending")}");
                }
                catch
                {

                }
            }

            await HttpContext.InsertPaginationParametersInResponse(peopleQueryable, filterPersonDTO.RecordsPerPage);

            var people = await peopleQueryable.Paginate(filterPersonDTO.Pagination).ToListAsync();

            return mapper.Map<List<PersonDTO>>(people);
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PersonCreationDTO personCreationDTO)
        {
            var person = mapper.Map<Person>(personCreationDTO);

            if (personCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await personCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(personCreationDTO.Picture.FileName);
                    person.Picture = await fileStorageService.SaveFile(content, extension, containerName, personCreationDTO.Picture.ContentType);
                }
            }

            dbContext.Add(person);
            await dbContext.SaveChangesAsync();
            var personDTO = mapper.Map<PersonDTO>(person);

            return new CreatedAtRouteResult("getPerson", new { id = personDTO.Id }, personDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] PersonCreationDTO personCreationDTO)
        {
            var personDb = await dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if (personDb == null)
            {
                return NotFound();
            }

            personDb = mapper.Map(personCreationDTO, personDb);

            if (personCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await personCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(personCreationDTO.Picture.FileName);
                    personDb.Picture = await fileStorageService.EditFile(content, extension, containerName, personDb.Picture, personCreationDTO.Picture.ContentType);
                }
            }

            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<PersonPatchDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var entityFromDb = await dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if (entityFromDb == null)
            {
                return NotFound();
            }

            var entityDTO = mapper.Map<PersonPatchDTO>(entityFromDb);

            patchDocument.ApplyTo(entityDTO, ModelState);

            var isValid = TryValidateModel(entityDTO);
            if (!isValid)
            {
                return BadRequest(ModelState);
            }
            mapper.Map(entityDTO, entityFromDb);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.People.AnyAsync(p => p.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            dbContext.Remove(new Person() {Id = id});
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}