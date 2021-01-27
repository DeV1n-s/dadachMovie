using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public string ImdbRate { get; set; }

        [JsonIgnore]
        public string ImdbRatesCount { get; set; }

        [JsonIgnore]
        public string MetacriticRate { get; set; }
        public int Lenght { get; set; }
        public bool InTheaters { get; set; }
        
        [Required]
        [ImdbIdValidator]
        public string ImdbId { get; set; }
    }
}