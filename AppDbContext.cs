using System.Diagnostics.CodeAnalysis;
using dadachMovie.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) 
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesGenres>()
                .HasKey(x => new {x.GenreId, x.MovieId});
            
            modelBuilder.Entity<MoviesCasts>()
                .HasKey(x => new {x.MovieId, x.PersonId});
            
            modelBuilder.Entity<MoviesDirectors>()
                .HasKey(x => new {x.MovieId, x.PersonId});
            
            modelBuilder.Entity<MoviesCountries>()
                .HasKey(x => new {x.MovieId, x.CountryId});
            
            modelBuilder.Entity<PeopleCountries>()
                .HasKey(x => new {x.PersonId, x.CountryId});

            modelBuilder.Entity<Country>()
                .HasData(dadachMovie.Helpers.SeedHelper.SeedData<Country>("countries.json"));
            
            modelBuilder.Entity<Movie>()
                .HasIndex(x => x.ImdbId).IsUnique();
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<MoviesCasts> MoviesCasts { get; set; }
        public DbSet<MoviesDirectors> MoviesDirectors { get; set; }
        public DbSet<MoviesCountries> MoviesCountries { get; set; }
        public DbSet<PeopleCountries> PeopleCountries { get; set; }
    }
}