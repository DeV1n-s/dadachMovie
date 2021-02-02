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
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Seasons { get; set; }
        public int? Episodes { get; set; }
        public SeriesStatus Status { get; set; }
        public DaysEnum? AirDay { get; set; }

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