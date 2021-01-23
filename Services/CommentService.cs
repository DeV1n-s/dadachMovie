using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public CommentService(AppDbContext dbContext,
                            IMapper mapper,
                            ILoggerService logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> DeleteCommentAsync(int id)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Remove(comment);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Comment with ID {id} was deleted successfully.");
                return 1;
            }
            catch (System.Exception ex)
            {
                _logger.LogWarn($"Failed to delete comment with ID {id}. Exception: {ex}");
                return -1;
            }
        }

        public async Task<int> SaveCommentAsync(CommentCreationDTO commentCreationDTO)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == commentCreationDTO.MovieId);
            var entity = _mapper.Map<Comment>(commentCreationDTO);
            movie.Comments.Add(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Comment with ID {entity.Id} was added successfully.");
                return 1;
            }
            catch (System.Exception ex)
            {
                _logger.LogWarn($"Failed to add comment with ID {entity.Id}. Exception: {ex}");
                return -1;
            }
        }
    }
}