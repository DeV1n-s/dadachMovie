using System;
using System.ComponentModel.DataAnnotations;
using dadachMovie.Validations;

namespace dadachMovie.DTOs
{
    public class MoviePatchDTO
    {
        //public int? Id { get; set; } // Nullable Id instead of getting Id from user in a seperate parameter
        [Required, MaxLength(300)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rate { get; set; }
        public int Lenght { get; set; }
        public bool InTheaters { get; set; }
        
        [ImdbIdValidator]
        public string ImdbId { get; set; }
    }
}