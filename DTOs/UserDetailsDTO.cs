using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class UserDetailsDTO : UserDTO
    {
        public List<string> Roles { get; set; } = new List<string>();
        public List<UserMovieRatingDTO> MoviesRatings { get; set; }
        public List<FavoriteMovieDTO> FavoriteMovies { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public List<RequestDTO> Requests { get; set; }
    }
}