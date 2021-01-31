using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dadachMovie.Enums;
using dadachMovie.Validations;

namespace dadachMovie.Entities
{
    public class Serie : BaseEntity
    {
        public Serie()
        {
            Casts = new List<SeriesCasts>();
            Genres = new List<Genre>();
            Directors = new List<Person>();
            Countries = new List<Country>();
            SeriesRatings = new List<SeriesRating>();
            Users = new List<User>();
            Comments = new List<Comment>();
            Status = SeriesStatus.Upcoming;
        }
        
        public int Id { get; set; }
        
        [Required, MaxLength(300)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public int? Seasons { get; set; }
        public int? Episodes { get; set; }
        public SeriesStatus Status { get; set; }
        public string ImdbRate { get; set; }
        public string ImdbRatesCount { get; set; }
        public string MetacriticRate { get; set; }
        public int? Lenght { get; set; }

        [Required, ImdbIdValidator]
        public string ImdbId { get; set; }
        public string Picture { get; set; }  = "http://localhost:5000/movies/default.png";
        public string BannerImage { get; set; } = "http://localhost:5000/movies/defaultbanner.png";
        
        public virtual ICollection<SeriesCasts> Casts { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Person> Directors { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<SeriesRating> SeriesRatings { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}