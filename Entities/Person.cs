using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dadachMovie.Entities
{
    public partial class Person
    {
        public Person()
        {
            Categories = new List<Category>();
            Movies = new List<Movie>();
            Series = new List<Serie>();
        }
        
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Name { get; set; }
        public string ShortBio { get; set; }
        public string Biography { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public string Picture { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
        public int? CountryId { get; set; }
        
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
    }
}