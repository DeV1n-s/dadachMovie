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
            modelBuilder.Entity<MoviesGenres>()
                .HasKey(x => new {x.GenreId, x.MovieId});
            
            modelBuilder.Entity<MoviesCasters>()
                .HasKey(x => new {x.MovieId, x.PersonId});
            
            modelBuilder.Entity<MoviesDirectors>()
                .HasKey(x => new {x.MovieId, x.PersonId});
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<MoviesCasters> MoviesCasters { get; set; }
        public DbSet<MoviesDirectors> MoviesDirectors { get; set; }
    }
}