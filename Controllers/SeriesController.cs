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
    [Route("api/series")]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;
        private readonly IMapper _mapper;

        public SeriesController(ISeriesService seriesService,
                                IMapper mapper)
        {
            _seriesService = seriesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Paging<SerieDTO>>> GetSeries(int? genreId, [FromQuery] GridifyQuery gridifyQuery) =>
            await _seriesService.GetSeriesPagingAsync(genreId, gridifyQuery);
        
        [HttpGet("UpcomingReleases")]
        public async Task<ActionResult<Paging<SerieDTO>>> GetUpcomingReleases([FromQuery] GridifyQuery gridifyQuery) =>
            await _seriesService.GetUpcomingReleasesAsync(gridifyQuery);
        
        [HttpGet("{id:int}", Name = "getSerie")]
        [ServiceFilter(typeof(UserActivityFilter))]
        public async Task<ActionResult<SerieDetailsDTO>> GetSerieById(int id)
        {
            var serie = await _seriesService.GetSerieDetailsByIdAsync(id);
            if (serie == null)
                return NotFound();

            return serie;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> PostSerie([FromForm] SerieCreationDTO serieCreationDTO)
        {
            var exists = await _seriesService.CheckImdbIdAsync(serieCreationDTO.ImdbId);
            if (exists == 1)
                return BadRequest($"ImdbId {serieCreationDTO.ImdbId} already exists.");

            var serieDTO = await _seriesService.AddSerieAsync(serieCreationDTO);
            return new CreatedAtRouteResult("getSerie", new { Id = serieDTO.Id }, serieDTO);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> PutSerie(int id, [FromForm] SerieCreationDTO serieCreationDTO)
        {
            var result = await _seriesService.UpdateSerieAsync(id, serieCreationDTO);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<SeriePatchDTO> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            var entityFromDb = await _seriesService.GetSerieByIdAsync(id);
            if (entityFromDb == null)
                return NotFound();

            var entityDTO = _mapper.Map<SeriePatchDTO>(entityFromDb);
            patchDocument.ApplyTo(entityDTO, ModelState);

            _mapper.Map(entityDTO, entityFromDb);
            await _seriesService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ValidateModelAttribute]
        public async Task<ActionResult> DeleteSerie(int id)
        {
            var result = await _seriesService.DeleteSerieAsync(id);
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
            var result = await _seriesService.AddUserCommentAsync(commentCreationDTO);
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
            var result = await _seriesService.DeleteUserCommentAsync(id);
            if (result == -1)
                return NotFound();
            else if (result == 0)
                return BadRequest("Failed to save changes.");

            return NoContent();
        }
    }
}