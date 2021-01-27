using System;
using System.Collections.Generic;
using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasIndex(i => i.ImdbId).IsUnique();
            builder.HasData(new Movie
                {
                    Id = 1,
                    Title = "Mad Max: Fury Road",
                    ShortDescription = "Short info",
                    Description = "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search for her homeland with the aid of a group of female prisoners, a psychotic worshiper, and a drifter named Max.",
                    ReleaseDate = new DateTime(2015, 3, 15),
                    ImdbId = "tt1392190",
                    ImdbRate = "8.1",
                    ImdbRatesCount = "881077",
                    MetacriticRate = "90",
                    Lenght = 120,
                    InTheaters = false,
                    Picture = "http://localhost:5000/movies/madmaxfuryroad.jpg",
                    CreatedAt = new DateTime(2021, 1, 25, 17, 46, 10, 814, DateTimeKind.Local),
                    UpdatedAt = new DateTime(2021, 1, 25, 17, 46, 10, 814, DateTimeKind.Local)
                });

            builder.HasMany(x => x.Countries).WithMany(y => y.Movies)
                        .UsingEntity<Dictionary<string, object>>(
                            "CountryMovie",
                            r => r.HasOne<Country>().WithMany().HasForeignKey("CountryId"),
                            l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                            z =>
                            {
                                z.HasKey("CountryId", "MovieId");
                                z.HasData(
                                    new {CountryId = 248, MovieId = 1}
                                );
                            }
                        );

            builder.HasMany(x => x.Genres).WithMany(y => y.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "GenreMovie",
                    r => r.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    z =>
                    {
                        z.HasKey("GenreId", "MovieId");
                        z.HasData(
                            new {GenreId = 1, MovieId = 1},
                            new {GenreId = 8, MovieId = 1},
                            new {GenreId = 15, MovieId = 1}
                        );
                    }
                );
        }
    }
}