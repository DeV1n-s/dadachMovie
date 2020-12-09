using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public GenresController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var genres = await dbContext.Genres.ToListAsync();

            return mapper.Map<List<GenreDTO>>(genres);
        }

        [HttpGet("{id}", Name = "getGenre")]
        public async Task<ActionResult<GenreDTO>> GetById(int id)
        {
            var genre = await dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            
            return mapper.Map<GenreDTO>(genre);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            dbContext.Add(genre);
            await dbContext.SaveChangesAsync();
            var genreDTO = mapper.Map<GenreDTO>(genre);

            return new CreatedAtRouteResult("getGenre", new {genreDTO.Id}, genreDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            dbContext.Entry(genre).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.Genres.AnyAsync(g => g.Id == id);

            if (!exists)
            {
                NotFound();
            }
            dbContext.Remove(new Genre { Id = id });
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}