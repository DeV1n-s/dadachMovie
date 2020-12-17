using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
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
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;

        private readonly string containerName = "movies";

        public MoviesController(AppDbContext dbContext, IMapper mapper, IFileStorageService fileStorageService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDetailsDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = dbContext.Movies
                                    .Include(m => m.Casts).ThenInclude(m => m.Person)
                                    .Include(m => m.Genres).ThenInclude(m => m.Genre)
                                    .Include(m => m.Directors).ThenInclude(m => m.Person)
                                    .AsQueryable();
                                    
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            var movies = await queryable
                                .Paginate(paginationDTO)
                                .OrderByDescending(m => m.Id)
                                .ToListAsync();

            return mapper.Map<List<MovieDetailsDTO>>(movies);
        }

        [HttpGet("top")]
        public async Task<ActionResult<IndexMoviePageDTO>> GetTop([FromQuery] int amount)
        {
            if (amount == 0)
            {
                amount = 5;
            }
            var today = DateTime.Today;
            var upcomingReleases = await dbContext.Movies
                .Where(m => m.ReleaseDate > today)
                .OrderByDescending(m => m.ReleaseDate)
                .Take(amount)
                .ToListAsync();

            var inTheaters = await dbContext.Movies
                .Where(m => m.InTheaters)
                .OrderByDescending(m => m.Id)
                .Take(amount)
                .ToListAsync();

            var result = new IndexMoviePageDTO();
            result.InTheaters = mapper.Map<List<MovieDTO>>(inTheaters);
            result.UpcomingReleases = mapper.Map<List<MovieDTO>>(upcomingReleases);

            return result;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<MovieDTO>>> Filter([FromQuery] FilterMoviesDTO filterMoviesDTO)
        {
            var moviesQueryable = dbContext.Movies.AsQueryable();
            if (!string.IsNullOrWhiteSpace(filterMoviesDTO.Title))
            {
                moviesQueryable = moviesQueryable.Where(m => m.Title.Contains(filterMoviesDTO.Title));
            }

            if (filterMoviesDTO.InTheaters)
            {
                moviesQueryable = moviesQueryable.Where(m => m.InTheaters);
            }

            if (filterMoviesDTO.UpcomingReleases)
            {
                moviesQueryable = moviesQueryable.Where(m => m.ReleaseDate > DateTime.Today);
            }

            if (filterMoviesDTO.GenreId != 0)
            {
                moviesQueryable = moviesQueryable.Where(m => m.Genres.Select(x => x.GenreId)
                .Contains(filterMoviesDTO.GenreId));
            }

            if (!string.IsNullOrWhiteSpace(filterMoviesDTO.OrderingField))
            {
                try
                {
                    moviesQueryable = moviesQueryable
                        .OrderBy($"{filterMoviesDTO.OrderingField} {(filterMoviesDTO.AscendingOrder ? "ascending" : "descending")}");
                }
                catch
                {

                }
            }

            await HttpContext.InsertPaginationParametersInResponse(moviesQueryable, filterMoviesDTO.RecordsPerPage);

            var movies = await moviesQueryable.Paginate(filterMoviesDTO.Pagination).ToListAsync();

            return mapper.Map<List<MovieDTO>>(movies);
        }

        [HttpGet("{id:int}", Name = "getMovie")]
        public async Task<ActionResult<MovieDetailsDTO>> GetById(int id)
        {
            var movie = await dbContext.Movies
                .Include(m => m.Casts).ThenInclude(m => m.Person)
                .Include(m => m.Genres).ThenInclude(m => m.Genre)
                .Include(m => m.Directors).ThenInclude(m => m.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return mapper.Map<MovieDetailsDTO>(movie);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] MovieCreationDTO movieCreationDTO)
        {
            var movie = mapper.Map<Movie>(movieCreationDTO);

            if (movieCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await movieCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(movieCreationDTO.Picture.FileName);
                    movie.Picture = 
                        await fileStorageService.SaveFile(content, extension, containerName,
                                                            movieCreationDTO.Picture.ContentType);
                }
            }

            AnnotateCastsOrder(movie);

            dbContext.Add(movie);
            await dbContext.SaveChangesAsync();
            var movieDTO = mapper.Map<MovieDTO>(movie);

            return new CreatedAtRouteResult("getMovie", new { Id = movieDTO.Id }, movieDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] MovieCreationDTO movieCreationDTO)
        {
            var movieDb = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movieDb == null)
            {
                return NotFound();
            }

            movieDb = mapper.Map(movieCreationDTO, movieDb);

            if (movieCreationDTO.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await movieCreationDTO.Picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(movieCreationDTO.Picture.FileName);
                    movieDb.Picture = 
                        await fileStorageService.EditFile(content, extension, containerName,
                                                            movieDb.Picture,
                                                            movieCreationDTO.Picture.ContentType);
                }
            }
            
            await dbContext.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM MoviesActors WHERE MovieId = {movieDb.Id}; DELETE FROM MoviesGenres WHERE MovieId = {movieDb.Id}; DELETE FROM MoviesDirectors WHERE MovieId = {movieDb.Id};");

            AnnotateCastsOrder(movieDb);

            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<MoviePatchDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var entityFromDb = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (entityFromDb == null)
            {
                return NotFound();
            }

            var entityDTO = mapper.Map<MoviePatchDTO>(entityFromDb);

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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.Movies.AnyAsync(m => m.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            dbContext.Remove(new Movie() {Id = id});
            await dbContext.SaveChangesAsync();
            return NoContent();

        }

        private static void AnnotateCastsOrder(Movie movie)
        {
            if (movie.Casts != null)
            {
                for (int i = 0; i < movie.Casts.Count; i++)
                {
                    movie.Casts[i].Order = i;
                }
            }
        }
    }
}