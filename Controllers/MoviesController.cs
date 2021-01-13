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
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesService moviesService,
                                IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Paging<MovieDetailsDTO>>> Get([FromQuery] GridifyQuery gridifyQuery) =>
            await _moviesService.GetMoviesDetailsPagingAsync(gridifyQuery);

        [HttpGet("top")]
        public async Task<ActionResult<IndexMoviePageDTO>> GetTop([FromQuery] int amount) =>
            await _moviesService.GetTopMoviesAsync(amount);

        [HttpGet("{id:int}", Name = "getMovie")]
        public async Task<ActionResult<MovieDetailsDTO>> GetById(int id)
        {
            var movie = await _moviesService.GetMovieByIdAsync(id);
            if (movie == null)
                return NotFound();

            return movie;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post([FromForm] MovieCreationDTO movieCreationDTO)
        {
            var exists = await _moviesService.CheckImdbIdAsync(movieCreationDTO.ImdbId);
            if (exists == 1)
                return BadRequest($"ImdbId {movieCreationDTO.ImdbId} already exists.");

            var movieDTO = await _moviesService.AddMovieAsync(movieCreationDTO);
            return new CreatedAtRouteResult("getMovie", new { Id = movieDTO.Id }, movieDTO);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(int id, [FromForm] MovieCreationDTO movieCreationDTO)
        {
            var result = await _moviesService.UpdateMovieAsync(id, movieCreationDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<MoviePatchDTO> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            var entityFromDb = await _moviesService.GetMovieByIdAsync(id);
            if (entityFromDb == null)
                return NotFound();

            var entityDTO = _mapper.Map<MoviePatchDTO>(entityFromDb);
            patchDocument.ApplyTo(entityDTO, ModelState);

            var isValid = TryValidateModel(entityDTO);
            if (!isValid)
                return BadRequest(ModelState);

            _mapper.Map(entityDTO, entityFromDb);
            await _moviesService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _moviesService.DeleteMovieAsync(id);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }
    }
}