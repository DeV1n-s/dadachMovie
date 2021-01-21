using System;
using System.Threading.Tasks;
using dadachMovie.Contracts;
using dadachMovie.DTOs;
using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie.Services
{
    public class RatingService : IRatingService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILoggerService _logger;

        public RatingService(AppDbContext dbContext,
                            ILoggerService logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<int> SaveRatingAsync(MovieRatingDTO movieRatingDTO)
        {
            var rating = await _dbContext.MoviesRating.FirstOrDefaultAsync(mr => mr.MovieId == movieRatingDTO.MovieId && mr.UserId == Guid.Parse(movieRatingDTO.UserId));

            if (rating != null)
            {
                rating.Rate = movieRatingDTO.Rate;
            }
            else
            {
                rating = new MoviesRating
                {
                    MovieId = movieRatingDTO.MovieId,
                    UserId = Guid.Parse(movieRatingDTO.UserId),
                    Rate = movieRatingDTO.Rate
                };

                await _dbContext.MoviesRating.AddAsync(rating);
            }

            try
            {
                await _dbContext.SaveChangesAsync();
                _logger.LogInfo($"Successfully saved MoviesRating with rating {movieRatingDTO.Rate} from user {movieRatingDTO.UserId} to movie {movieRatingDTO.MovieId}");
                return 1;
            }
            catch (Exception ex)
            {
                _logger.LogWarn($"Failed to save MoviesRating with rating {movieRatingDTO.Rate} from user {movieRatingDTO.UserId} to movie {movieRatingDTO.MovieId}. Exception: {ex}");
                return -1;
            }
        }
    }
}