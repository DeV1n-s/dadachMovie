using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class UserFavoriteMoviesDTO
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
    }
}