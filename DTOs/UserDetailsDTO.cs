using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class UserDetailsDTO : UserDTO
    {
        public List<UserMovieRatingDTO> MoviesRatings { get; set; }
        public List<FavoriteMovieDTO> FavoriteMovies { get; set; }
    }
}