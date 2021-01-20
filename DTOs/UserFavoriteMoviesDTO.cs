using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class UserFavoriteMoviesDTO
    {
        public string UserId { get; set; }
        public int FavoriteMoviesId { get; set; }
    }
}