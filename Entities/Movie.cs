using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dadachMovie.Validations;

namespace dadachMovie.Entities
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            Casts = new List<MoviesCasts>();
            Genres = new List<Genre>();
            Directors = new List<Person>();
            Countries = new List<Country>();
            MoviesRatings = new List<MoviesRating>();
            Users = new List<User>();
            Comments = new List<Comment>();
        }
        
        public int Id { get; set; }
        
        [Required, MaxLength(300)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public string ImdbRate { get; set; }
        public string ImdbRatesCount { get; set; }
        public string MetacriticRate { get; set; }
        public int? Lenght { get; set; }
        public bool InTheaters { get; set; } = false;

        [Required, ImdbIdValidator]
        public string ImdbId { get; set; }
        public string Picture { get; set; }  = "http://localhost:5000/movies/default.png";
        public string BannerImage { get; set; } = "http://localhost:5000/movies/defaultbanner.png";
        
        public virtual ICollection<MoviesCasts> Casts { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Person> Directors { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<MoviesRating> MoviesRatings { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}