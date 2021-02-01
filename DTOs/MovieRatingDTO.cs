using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dadachMovie.DTOs
{
    public class MovieRatingDTO
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required,Range(1,10)]
        public int Rate { get; set; }
    }
}