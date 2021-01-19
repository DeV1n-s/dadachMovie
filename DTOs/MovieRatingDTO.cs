using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class MovieRatingDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public byte Rating { get; set; }
    }
}