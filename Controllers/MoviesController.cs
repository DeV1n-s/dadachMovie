using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<List<MovieDetailsDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {                           
            var moviesQueryable = _moviesService.GetMoviesDetailsQueryable();
            if( moviesQueryable == null)
                return UnprocessableEntity("Failed to get MoviesDetailsList from service.");

            await HttpContext.InsertPaginationParametersInResponse(moviesQueryable, paginationDTO.RecordsPerPage);
            return await moviesQueryable.Paginate(paginationDTO)
                                .OrderByDescending(m => m.Id)
                                .ToListAsync();
        }

        [HttpGet("top")]
        public async Task<ActionResult<IndexMoviePageDTO>> GetTop([FromQuery] int amount) =>
            await _moviesService.GetTopMoviesAsync(amount);

        [HttpGet("filter")]
        public async Task<ActionResult<List<MovieDTO>>> Filter([FromQuery] FilterMoviesDTO filterMoviesDTO)
        {
            var moviesQueryable = _moviesService.GetMoviesQueryable();
            if (!string.IsNullOrWhiteSpace(filterMoviesDTO.Title))
                moviesQueryable = moviesQueryable.Where(m => m.Title.Contains(filterMoviesDTO.Title));

            if (filterMoviesDTO.InTheaters)
                moviesQueryable = moviesQueryable.Where(m => m.InTheaters);

            if (filterMoviesDTO.UpcomingReleases)
                moviesQueryable = moviesQueryable.Where(m => m.ReleaseDate > DateTime.Today);

            if (filterMoviesDTO.GenreId != 0)
                moviesQueryable = moviesQueryable.Where(m => m.Genres.Select(x => x.GenreId)
                                                .Contains(filterMoviesDTO.GenreId));

            if (!string.IsNullOrWhiteSpace(filterMoviesDTO.OrderingField))
            {
                try
                {
                    moviesQueryable = moviesQueryable
                        .OrderBy($"{filterMoviesDTO.OrderingField} {(filterMoviesDTO.AscendingOrder ? "ascending" : "descending")}");
                }
                catch
                { }
            }

            await HttpContext.InsertPaginationParametersInResponse(moviesQueryable, filterMoviesDTO.RecordsPerPage);
            var movies = await moviesQueryable.Paginate(filterMoviesDTO.Pagination).ToListAsync();
            return _mapper.Map<List<MovieDTO>>(movies);
        }

        [HttpGet("{id:int}", Name = "getMovie")]
        public async Task<ActionResult<MovieDetailsDTO>> GetById(int id)
        {
            var movie = await _moviesService.GetMovieByIdAsync(id);
            if (movie == null)
                return NotFound();

            return movie;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] MovieCreationDTO movieCreationDTO)
        {
            var movieDTO = await _moviesService.AddMovieAsync(movieCreationDTO);
            return new CreatedAtRouteResult("getMovie", new { Id = movieDTO.Id }, movieDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] MovieCreationDTO movieCreationDTO)
        {
            if (!await _moviesService.UpdateMovieAsync(id, movieCreationDTO))
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
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
        public async Task<ActionResult> Delete(int id)
        {
            if (!await _moviesService.DeleteMovieAsync(id))
                return NotFound();

            return NoContent();
        }
    }
}