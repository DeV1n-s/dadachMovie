using System;
using System.ComponentModel.DataAnnotations;
using dadachMovie.Validations;

namespace dadachMovie.DTOs
{
    public class MoviePatchDTO
    {
        [Required, MaxLength(300)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rate { get; set; }
        public bool InTheaters { get; set; }
        
        [ImdbIdValidator]
        public string ImdbId { get; set; }
    }
}