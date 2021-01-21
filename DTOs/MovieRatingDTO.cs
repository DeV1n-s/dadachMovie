using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class MovieRatingDTO
    {
        public string UserId { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required,Range(1,10)]
        public int Rate { get; set; }
    }
}