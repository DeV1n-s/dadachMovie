using System.Diagnostics.CodeAnalysis;
using dadachAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace dadachAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) 
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesGenres>()
                .HasKey(x => new {x.GenreId, x.MovieId});
            
            modelBuilder.Entity<MoviesActors>()
                .HasKey(x => new {x.MovieId, x.PersonId});
            
            modelBuilder.Entity<MoviesDirectors>()
                .HasKey(x => new {x.MovieId, x.PersonId});

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<MoviesDirectors> MoviesDirectors { get; set; }

    }
}