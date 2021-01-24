using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class MoviesRatingConfiguration : IEntityTypeConfiguration<MoviesRating>
    {
        public void Configure(EntityTypeBuilder<MoviesRating> builder)
        {
            builder.HasKey(pk => new {pk.MovieId, pk.UserId});
        }
    }
}