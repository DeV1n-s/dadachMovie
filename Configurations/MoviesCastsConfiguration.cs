using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class MoviesCastsConfiguration : IEntityTypeConfiguration<MoviesCasts>
    {
        public void Configure(EntityTypeBuilder<MoviesCasts> builder)
        {
            builder.HasKey(pk => new {pk.MovieId, pk.PersonId});
            builder.HasData
            (
                new MoviesCasts
                {
                    MovieId = 1,
                    PersonId = 1,
                    Character = "Max Rockatansky",
                    Order = 0
                },
                new MoviesCasts
                {
                    MovieId = 1,
                    PersonId = 2,
                    Character = "Imperator Furiosa",
                    Order = 1
                },
                new MoviesCasts
                {
                    MovieId = 1,
                    PersonId = 4,
                    Character = "Viewer",
                    Order = 2
                }
            );
        }
    }
}