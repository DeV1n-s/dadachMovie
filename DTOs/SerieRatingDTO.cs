using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dadachMovie.DTOs
{
    public class SerieRatingDTO
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required]
        public int SerieId { get; set; }

        [Required,Range(1,10)]
        public int Rate { get; set; }
    }
}