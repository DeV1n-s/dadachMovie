using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using Gridify;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        public async Task<ActionResult<Paging<GenreDTO>>> Get([FromQuery] GridifyQuery gridifyQuery)
        {
            var genres = await _genresService.GetGenresPagingAsync(gridifyQuery);
            if( genres == null)
                return UnprocessableEntity("Failed to get Genres from service.");

            return genres;
        }

        [HttpGet("{id}", Name = "getGenre")]
        public async Task<ActionResult<GenreDTO>> GetById(int id)
        {
            var genreDTO = await _genresService.GetGenreByIdAsync(id);
            if (genreDTO == null)
                return NotFound();

            return genreDTO;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genreDTO = await _genresService.AddGenreAsync(genreCreationDTO);
            return new CreatedAtRouteResult("getGenre", new { genreDTO.Id }, genreDTO);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            if (!await _genresService.UpdateGenreAsync(id, genreCreationDTO))
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!await _genresService.DeleteGenreAsync(id))
                return NotFound();

            return NoContent();
        }
    }
}