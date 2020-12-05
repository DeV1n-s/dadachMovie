using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dadachAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, StringLength(300)]
        public string Title { get; set; }
        public string ShortPara { get; set; }
        public string LongPara { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rate { get; set; }
        public bool InTheaters { get; set; }
        public string Picture { get; set; }
        public List<MoviesActors> Casters { get; set; }
        public List<MoviesGenres> Genres { get; set; }
        public List<MoviesDirectors> Directors { get; set; }

    }
}