using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dadachMovie.Validations;

namespace dadachMovie.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required, MaxLength(300)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public float ImdbRate { get; set; }
        public int Lenght { get; set; }
        public bool InTheaters { get; set; }

        [ImdbIdValidator]
        public string ImdbId { get; set; }
        public string Picture { get; set; }

        public List<MoviesCasts> Casts { get; set; } = new List<MoviesCasts>();
        public List<MoviesGenres> Genres { get; set; } = new List<MoviesGenres>();
        public List<MoviesDirectors> Directors { get; set; } = new List<MoviesDirectors>();
        public List<MoviesCountries> Countries { get; set; } = new List<MoviesCountries>();
        public virtual ICollection<MoviesRating> MoviesRatings { get; set; }
        public virtual ICollection<User> Users { get; set; }
    } 
}