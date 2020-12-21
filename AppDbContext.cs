using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using dadachMovie.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dadachMovie
{
    public class AppDbContext : IdentityDbContext
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

        // private void SeedCountryData(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Country>().HasData(
        //         new Country { Name = "Afghanistan", Nationality = "Afghan", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Albania", Nationality = "Albanian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Åland Islands", Nationality = "Åland Island", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Algeria", Nationality = "Algerian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "American Samoa", Nationality = "American Samoan", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Andorra", Nationality = "Andorran", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Angola", Nationality = "Angolan", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Anguilla", Nationality = "Anguillan", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Antarctica", Nationality = "Antarctican", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Antigua and Barbuda", Nationality = "Antiguan", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Argentina", Nationality = "Argentinian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Armenia", Nationality = "Armenian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Aruba", Nationality = "Aruban", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Australia", Nationality = "Australian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Austria", Nationality = "Austrian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Azerbaijan", Nationality = "Azerbaijani", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bahamas", Nationality = "Bahamian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bahrain", Nationality = "Bahraini", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bangladesh", Nationality = "Bangladeshi", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Barbados", Nationality = "Barbadian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Belarus", Nationality = "Belarusian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Belgium", Nationality = "Belgian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Belize", Nationality = "Belizean", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Benin", Nationality = "Beninese", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bermuda", Nationality = "Bermudan", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bhutan", Nationality = "Bhutanese", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bolivia", Nationality = "Bolivian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bosnia and Herzegovina", Nationality = "Bosnian / Herzegovinian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Botswana", Nationality = "Botswanan", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bouvet Island", Nationality = "Bouvetian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Brazil", Nationality = "Brazilian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "British Indian Ocean Territory", Nationality = "British Indian Ocean Territory", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Brunei Darussalam", Nationality = "Bruneian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Bulgaria", Nationality = "Bulgarian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Burkina Faso", Nationality = "Burkinabe", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Burundi", Nationality = "Burundian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Cambodia", Nationality = "Cambodian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Cameroon", Nationality = "Cameroonian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Canada", Nationality = "Canadian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Cape Verde", Nationality = "Cape Verdean", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Cayman Islands", Nationality = "Caymanian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Central African Republic", Nationality = "Central African", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Chad", Nationality = "Chadian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Chile", Nationality = "Chilean", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "China", Nationality = "Chinese", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Christmas Island", Nationality = "Christmas Islander", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Cocos (Keeling) Islands", Nationality = "Cocos Islander", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Colombia", Nationality = "Colombian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Comoros", Nationality = "Comorian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Congo", Nationality = "Congolese", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Cook Islands", Nationality = "Cook Islander", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Costa Rica", Nationality = "Costa Rican", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Croatia", Nationality = "Croatian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Cuba", Nationality = "Cuban", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Cyprus", Nationality = "Cypriot", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Curaçao", Nationality = "Curacian", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "", Nationality = "", Name_FA = "", Nationality_FA = ""},
        //         new Country { Name = "Saint Barthelemy", Nationality = "Saint Barthelmian", Name_FA = "", Nationality_FA = ""},
        //     );
        // }
    }
}