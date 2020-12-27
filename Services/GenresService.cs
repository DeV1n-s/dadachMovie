using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class GenresService : IGenresService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenresService(AppDbContext dbContext,
                            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GenreDTO>> GetGenresListAsync()
        {
            var genres = await _dbContext.Genres.AsNoTracking().ToListAsync();

            return _mapper.Map<List<GenreDTO>>(genres);
        }

        public async Task<GenreDTO> GetGenreByIdAsync(int id)
        {
            var genre = await _dbContext.Genres.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);

            return _mapper.Map<GenreDTO>(genre);
        }
        public async Task<GenreDTO> AddGenreAsync(GenreCreationDTO genreCreationDTO)
        {
            var genre = _mapper.Map<Genre>(genreCreationDTO);
            _dbContext.Add(genre);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task<bool> UpdateGenreAsync(int id, GenreCreationDTO genreCreationDTO)
        {
            var genre = _mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;

            _dbContext.Entry(genre).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var exists = await _dbContext.Genres.AnyAsync(g => g.Id == id);

            if (!exists)
            {
                return false;
            }

            _dbContext.Remove(new Genre { Id = id });
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}