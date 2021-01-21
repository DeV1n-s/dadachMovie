using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class UserFavoriteMoviesDTO
    {
        public string UserId { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}