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

        public GenresService(AppDbContext dbContext,
                            IMapper mapper)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Paging<GenreDTO>> GetGenresPagingAsync(GridifyQuery gridifyQuery)
        {
            var queryable = await _dbContext.Genres.GridifyQueryableAsync(gridifyQuery,null);
            return new Paging<GenreDTO> {Items = queryable.Query.ProjectTo<GenreDTO>(_mapper.ConfigurationProvider).ToList(),
                                        TotalItems = queryable.TotalItems};
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
            await this.SaveChangesAsync();
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task<int> UpdateGenreAsync(int id, GenreCreationDTO genreCreationDTO)
        {
            var exists = await _dbContext.Genres.AnyAsync(g => g.Id == id);
            if (!exists)
                return -1;
                
            var genre = _mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            _dbContext.Entry(genre).State = EntityState.Modified;

            try
            {
                await this.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> DeleteGenreAsync(int id)
        {
            var exists = await _dbContext.Genres.AnyAsync(g => g.Id == id);
            if (!exists)
                return -1;

            _dbContext.Remove(new Genre { Id = id });
            try
            {
                await this.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}