using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class SerieConfiguration : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.HasIndex(i => i.ImdbId).IsUnique();
            builder.Property(p => p.AirDay).HasConversion<string>();
            builder.Property(p => p.Status).HasConversion<string>();
        }
    }
}