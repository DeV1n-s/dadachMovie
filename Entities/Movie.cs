using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime ReleaseDate { get; set; }
        public float Rate { get; set; }
        public bool InTheaters { get; set; }

        [ImdbIdValidator]
        public string ImdbId { get; set; }
        public string Picture { get; set; }
        public List<MoviesCasters> Casters { get; set; } = new List<MoviesCasters>();
        public List<MoviesGenres> Genres { get; set; } = new List<MoviesGenres>();
        public List<MoviesDirectors> Directors { get; set; } = new List<MoviesDirectors>();
    }
    
}