using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dadachMovie.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dadachMovie
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) 
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesGenres>()
                .HasKey(pk => new {pk.GenreId, pk.MovieId});
            
            modelBuilder.Entity<MoviesCasts>()
                .HasKey(pk => new {pk.MovieId, pk.PersonId});
            
            modelBuilder.Entity<MoviesDirectors>()
                .HasKey(pk => new {pk.MovieId, pk.PersonId});
            
            modelBuilder.Entity<MoviesCountries>()
                .HasKey(pk => new {pk.MovieId, pk.CountryId});
            
            modelBuilder.Entity<PeopleCountries>()
                .HasKey(pk => new {pk.PersonId, pk.CountryId});

            modelBuilder.Entity<Country>()
                .HasData(dadachMovie.Helpers.SeedHelper.SeedData<Country>("countries.json"));
            
            modelBuilder.Entity<Movie>()
                .HasIndex(i => i.ImdbId).IsUnique();

            modelBuilder.Entity<Movie>()
                .HasMany(fk => fk.MoviesRatings)
                .WithOne(fk => fk.Movie)
                .HasForeignKey(fk => fk.MovieId);

            modelBuilder.Entity<User>()
                .HasMany(fk => fk.MoviesRatings)
                .WithOne(fk => fk.User)
                .HasForeignKey(fk => fk.UserId);
            
            modelBuilder.Entity<MoviesRating>()
                .HasKey(pk => new {pk.MovieId, pk.UserId});
            
            modelBuilder.Entity<MoviesRating>()
                .HasOne(fk => fk.Movie)
                .WithMany(fk => fk.MoviesRatings)
                .HasForeignKey(fk => fk.MovieId);
            
            modelBuilder.Entity<MoviesRating>()
                .HasOne(fk => fk.User)
                .WithMany(fk => fk.MoviesRatings)
                .HasForeignKey(fk => fk.UserId);
            
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
        public DbSet<MoviesRating> MoviesRating { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Request> Requests { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}