using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dadachAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortPara { get; set; }
        public string LongPara { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rate { get; set; }
        public bool InTheaters { get; set; }
        public string Picture { get; set; }
        public List<MoviesCasters> Casters { get; set; }
        public List<MoviesGenres> Genres { get; set; }
        public List<MoviesDirectors> Directors { get; set; }

        public Movie()
        {
            Casters = new List<MoviesCasters>();
            Genres = new List<MoviesGenres>();
            Directors = new List<MoviesDirectors>();
        }
    }
    
}