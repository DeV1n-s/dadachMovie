using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Validations;
using Gridify;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGenresService _genresService;

        public GenresController(AppDbContext dbContext,
                                IMapper mapper, 
                                IGenresService genresService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<ActionResult<Paging<GenreDetailsDTO>>> Get([FromQuery] GridifyQuery gridifyQuery)
        {
            var genres = await _genresService.GetGenresDetailsPagingAsync(gridifyQuery);
            if( genres == null)
                return UnprocessableEntity("Failed to get Genres from service.");

            return genres;
        }

        [HttpGet("{id}", Name = "getGenre")]
        public async Task<ActionResult<GenreDetailsDTO>> GetById(int id)
        {
            var genreDTO = await _genresService.GetGenreDetailsByIdAsync(id);
            if (genreDTO == null)
                return NotFound();

            return genreDTO;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genreDTO = await _genresService.AddGenreAsync(genreCreationDTO);
            return new CreatedAtRouteResult("getGenre", new { genreDTO.Id }, genreDTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            var result = await _genresService.UpdateGenreAsync(id, genreCreationDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _genresService.DeleteGenreAsync(id);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }
    }
}