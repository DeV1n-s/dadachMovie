using System;
using System.Collections.Generic;
using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dadachMovie.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData
            (
                new Person
                {
                    Id = 1,
                    Name = "Tom Hardy",
                    Biography = "Edward Thomas Hardy CBE is an English actor and producer. After studying acting at the Drama Centre London, he made his film debut in Ridley Scott's Black Hawk Down (2001). He has since been nominated for the Academy Award for Best Supporting Actor, two Critics' Choice Movie Awards and two BAFTA Awards, receiving the 2011 BAFTA Rising Star Award.",
                    DateOfBirth = new DateTime(1997, 9, 15),
                    Picture = "http://localhost:5000/people/tomhardy.jpg",
                    CountryId = 247
                },
                new Person
                {
                    Id = 2,
                    Name = "Charlize Theron",
                    Biography = "Charlize Theron is an Oscar-winning dramatic actress, action hero, and comedy star. Won 1 Oscar. Another 65 wins & 137 nominations.",
                    DateOfBirth = new DateTime(1975, 8, 7),
                    Picture = "http://localhost:5000/people/charlizetheron.jpg",
                    CountryId = 213
                },
                new Person
                {
                    Id = 3,
                    Name = "George Miller",
                    Biography = "George Miller is an Australian film director, screenwriter, producer, and former medical doctor. He is best known for his Mad Max franchise, with Mad Max 2: The Road Warrior (1981) and Mad Max: Fury Road (2015) being hailed as amongst the greatest action films of all time.",
                    DateOfBirth = new DateTime(1945, 3, 3),
                    Picture = "http://localhost:5000/people/georgemiller.jpg",
                    CountryId = 13
                },
                new Person
                {
                    Id = 4,
                    Name = "Aria Dark",
                    Biography = "blah blah",
                    DateOfBirth = new DateTime(1996, 2, 10),
                    Picture = "http://localhost:5000/people/ariadark.jpg",
                    CountryId = 106
                }
            );

            builder.HasMany(x => x.Categories).WithMany(y => y.People)
                        .UsingEntity<Dictionary<string, object>>(
                            "CategoryPerson",
                            r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                            l => l.HasOne<Person>().WithMany().HasForeignKey("PersonId"),
                            z =>
                            {
                                z.HasKey("CategoryId", "PersonId");
                                z.HasData(
                                    new {CategoryId = 1, PersonId = 1},
                                    new {CategoryId = 1, PersonId = 2},
                                    new {CategoryId = 2, PersonId = 3},
                                    new {CategoryId = 1, PersonId = 4},
                                    new {CategoryId = 2, PersonId = 4}
                                );
                            }
                        );
                    
            builder.HasMany(x => x.Movies).WithMany(y => y.Directors)
                .UsingEntity<Dictionary<string, object>>(
                    "MoviePerson",
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    l => l.HasOne<Person>().WithMany().HasForeignKey("PersonId"),
                    z =>
                    {
                        z.HasKey("MovieId", "PersonId");
                        z.HasData(
                            new {MovieId = 1, PersonId = 3}
                        );
                    }
                );
        }
    }
}