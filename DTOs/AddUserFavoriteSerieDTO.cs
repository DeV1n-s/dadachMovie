using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dadachMovie.DTOs
{
    public class AddUserFavoriteSerieDTO
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        
        [Required]
        public int SerieId { get; set; }
    }
}