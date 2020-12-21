using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dadachMovie.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Name { get; set; }
        public string ShortBio { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Picture { get; set; }
        public bool IsCast { get; set; }
        public bool IsDirector { get; set; }
        public List<MoviesCasts> Casts { get; set; } = new List<MoviesCasts>();
        public List<MoviesDirectors> Directors { get; set; } = new List<MoviesDirectors>();
        public PeopleCountries Country { get; set; }
    }
}