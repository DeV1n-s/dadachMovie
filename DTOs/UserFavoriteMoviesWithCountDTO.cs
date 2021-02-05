using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class UserFavoriteMoviesWithCountDTO
    {
        public int TotalItems { get; set; }
        public List<UserFavoriteMovieDTO> Items { get; set; }
    }
}