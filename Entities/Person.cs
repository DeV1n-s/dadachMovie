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
        public List<MoviesCasters> Casters { get; set; }
        public List<MoviesDirectors> Directors { get; set; }

        public Person()
        {
            Casters = new List<MoviesCasters>();
            Directors = new List<MoviesDirectors>();
        }
    }
}