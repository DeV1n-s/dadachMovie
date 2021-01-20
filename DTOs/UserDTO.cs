using System.Collections.Generic;
using dadachMovie.Entities;

namespace dadachMovie.DTOs
{
    public class UserDTO
    {
        public string EmailAddress { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Picture { get; set; }
        public string RegisterDate { get; set; }
        public List<UserMovieRatingDTO> MoviesRatings { get; set; }
        public List<MovieDTO> FavoriteMovies { get; set; }
    }
}