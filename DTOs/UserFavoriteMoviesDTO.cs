using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dadachMovie.DTOs
{
    public class UserFavoriteMoviesDTO
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}