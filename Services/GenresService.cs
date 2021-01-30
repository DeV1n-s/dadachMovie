using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class GenresService : BaseService, IGenresService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public GenresService(AppDbContext dbContext,
                            IMapper mapper,
                            ILoggerService logger)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Paging<GenreDetailsDTO>> GetGenresDetailsPagingAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Genres.AsNoTracking().GridifyQueryableAsync(gridifyQuery,null);
            return new Paging<GenreDetailsDTO> {Items = queryable.Query.ProjectTo<GenreDetailsDTO>(_mapper.ConfigurationProvider).ToList(),
                                                TotalItems = queryable.TotalItems};
        }

        public async Task<GenreDetailsDTO> GetGenreDetailsByIdAsync(int id) =>
            await _dbContext.Genres.AsNoTracking()
                                .ProjectTo<GenreDetailsDTO>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(g => g.Id == id);

        public async Task<GenreDTO> AddGenreAsync(GenreCreationDTO genreCreationDTO)
        {
            var genre = _mapper.Map<Genre>(genreCreationDTO);
            _dbContext.Add(genre);
            try
            {
                await this.SaveChangesAsync();
                _logger.LogInfo($"Added genre \"{genreCreationDTO.Name}\" successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to add genre \"{genreCreationDTO.Name}\". Eception: {ex}");
            }
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task<int> UpdateGenreAsync(int id, GenreCreationDTO genreCreationDTO)
        {
            var exists = await _dbContext.Genres.AnyAsync(g => g.Id == id);
            if (!exists)
            {
                _logger.LogWarn($"Genre with ID {id} was not found");
                return -1;
            }
                
            var genre = _mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            _dbContext.Entry(genre).State = EntityState.Modified;

            try
            {
                await this.SaveChangesAsync();
                _logger.LogInfo($"Genre \"{genreCreationDTO.Name}\" was updated successfully.");
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogWarn($"Failed to update genre \"{genreCreationDTO.Name}\". Exception: {ex}");
                return 0;
            }
        }

        public async Task<int> DeleteGenreAsync(int id)
        {
            var exists = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (exists == null)
            {
                _logger.LogWarn($"Genre with ID {id} was not found");
                return -1;
            }
                
            _dbContext.Remove(new Genre { Id = id });
            try
            {
                await this.SaveChangesAsync();
                _logger.LogInfo($"Genre \"{exists.Name}\" was removed successfully.");
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogWarn($"Failed to remove genre \"{exists.Name}\". Exception: {ex}");
                return 0;
            }
        }
    }
}