using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Helpers;
using dadachMovie.Validations;
using Gridify;
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
        public async Task<ActionResult<Paging<MovieDTO>>> Get(int? genreId, [FromQuery] GridifyQuery gridifyQuery) =>
            await _moviesService.GetMoviesPagingAsync(genreId, gridifyQuery);

        [HttpGet("UpcomingReleases")]
        public async Task<ActionResult<Paging<MovieDTO>>> GetUpcomingReleases([FromQuery] GridifyQuery gridifyQuery) =>
            await _moviesService.GetUpcomingReleasesAsync(gridifyQuery);
        
        [HttpGet("InTheaters")]
        public async Task<ActionResult<Paging<MovieDTO>>> GetInTheaters([FromQuery] GridifyQuery gridifyQuery) =>
            await _moviesService.GetInTheatersAsync(gridifyQuery);

        [HttpGet("{id:int}", Name = "getMovie")]
        [ServiceFilter(typeof(UserActivityFilter))]
        public async Task<ActionResult<MovieDetailsDTO>> GetById(int id)
        {
            var movie = await _moviesService.GetMovieByIdAsync(id);
            if (movie == null)
                return NotFound();

            return movie;
        }

        [HttpPost("SaveUserRating")]
        [ValidateModelAttribute]
        [Authorize]
        public async Task<ActionResult> SaveUserMovieRating([FromBody] MovieRatingDTO movieRatingDTO)
        {
            var result = await _moviesService.SaveUserMovieRatingAsync(movieRatingDTO);
            if (result == -1)
                return BadRequest(ModelState);
            
            return NoContent();
        }

        [HttpPost("SaveUserFavoriteMovies")]
        [ValidateModelAttribute]
        [Authorize]
        public async Task<ActionResult> SaveUserFavoriteMovies([FromBody] AddUserFavoriteMovieDTO addUserFavoriteMovieDTO)
        {
            var result = await _moviesService.SaveUserFavoriteMoviesAsync(addUserFavoriteMovieDTO);

            if (result == -2) {
                ModelState.TryAddModelError("movieId", $"Movie with ID {addUserFavoriteMovieDTO.MovieId} was not found.");
                return NotFound(ModelState);

            } else if(result == -3) {
                ModelState.TryAddModelError("userId", $"User with ID {addUserFavoriteMovieDTO.UserId} was not found.");
                return NotFound(ModelState);

            } else if (result == -1) {
                ModelState.TryAddModelError("saveChangesAsync", "Failed to save changes async.");
                return NotFound(ModelState);
            
            } else if (result == 0) {
                ModelState.TryAddModelError("alreadyExists", "User already favorited this movie.");
                return BadRequest(ModelState);
                
            } else {
                return NoContent();
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
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
        [ValidateModelAttribute]
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
        [ValidateModelAttribute]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<MoviePatchDTO> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            var entityFromDb = await _moviesService.GetMovieByIdAsync(id);
            if (entityFromDb == null)
                return NotFound();

            var entityDTO = _mapper.Map<MoviePatchDTO>(entityFromDb);
            patchDocument.ApplyTo(entityDTO, ModelState);

            _mapper.Map(entityDTO, entityFromDb);
            await _moviesService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _moviesService.DeleteMovieAsync(id);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpPost("AddUserComment")]
        [Authorize]
        [ValidateModel]
        public async Task<ActionResult> AddComment([FromBody] CommentCreationDTO commentCreationDTO)
        {
            var result = await _moviesService.AddUserCommentAsync(commentCreationDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpDelete("RemoveUserComment/{id:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        public async Task<ActionResult> RemoveComment(int id)
        {
            var result = await _moviesService.DeleteUserCommentAsync(id);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }
    }
}