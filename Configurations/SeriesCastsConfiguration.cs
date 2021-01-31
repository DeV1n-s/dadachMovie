using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class SeriesCastsConfiguration : IEntityTypeConfiguration<SeriesCasts>
    {
        public void Configure(EntityTypeBuilder<SeriesCasts> builder)
        {
            builder.HasKey(pk => new {pk.SerieId, pk.PersonId});
        }
    }
}