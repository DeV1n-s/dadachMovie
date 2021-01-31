using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class SeriesRatingConfiguration : IEntityTypeConfiguration<SeriesRating>
    {
        public void Configure(EntityTypeBuilder<SeriesRating> builder)
        {
            builder.HasKey(pk => new {pk.SerieId, pk.UserId});
        }
    }
}