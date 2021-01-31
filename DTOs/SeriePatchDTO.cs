using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using dadachMovie.Enums;
using dadachMovie.Validations;

namespace dadachMovie.DTOs
{
    public class SeriePatchDTO
    {
        [Required, MaxLength(300)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public int? Seasons { get; set; }
        public int? Episodes { get; set; }
        public SeriesStatus Status { get; set; }

        [JsonIgnore]
        public string ImdbRate { get; set; }

        [JsonIgnore]
        public string ImdbRatesCount { get; set; }

        [JsonIgnore]
        public string MetacriticRate { get; set; }
        public int? Lenght { get; set; }
        
        [Required]
        [ImdbIdValidator]
        public string ImdbId { get; set; }
    }
}