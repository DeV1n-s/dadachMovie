using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dadachMovie.DTOs
{
    public class AddUserFavoriteMovieDTO
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}