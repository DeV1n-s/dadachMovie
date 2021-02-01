using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class UserDetailsDTO : UserDTO
    {
        public List<string> Roles { get; set; } = new List<string>();
        public List<UserMovieRatingDTO> MoviesRatings { get; set; }
        public List<UserSerieRatingDTO> SeriesRatings { get; set; }
        public List<FavoriteMovieDTO> FavoriteMovies { get; set; }
        public List<FavoriteSerieDTO> FavoriteSeries { get; set; }
        public List<MovieCommentDTO> MovieComments { get; set; }
        public List<SerieCommentDTO> SerieComments { get; set; }
        public List<RequestDTO> Requests { get; set; }
    }
}