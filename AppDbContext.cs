using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using dadachMovie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dadachMovie
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) 
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // var converter = new EnumToStringConverter<PersonTypes>();

            // modelBuilder
            //     .Entity<Person>()
            //     .Property(e => e.PersonTypes)
            //     .HasConversion(converter);

            modelBuilder.Entity<MoviesGenres>()
                .HasKey(x => new {x.GenreId, x.MovieId});
            
            modelBuilder.Entity<MoviesCasters>()
                .HasKey(x => new {x.MovieId, x.PersonId});
            
            modelBuilder.Entity<MoviesDirectors>()
                .HasKey(x => new {x.MovieId, x.PersonId});
            
            modelBuilder.Entity<PersonType>()
                .HasKey(x => new {x.PersonId});

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<MoviesCasters> MoviesActors { get; set; }
        public DbSet<MoviesDirectors> MoviesDirectors { get; set; }
        public DbSet<PersonType> PersonType { get; set; }
    }
}