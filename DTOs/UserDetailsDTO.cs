using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class UserDetailsDTO : UserDTO
    {
        public List<string> Roles { get; set; } = new List<string>();
        public List<UserMovieRatingDTO> MoviesRatings { get; set; }
        public List<UserSerieRatingDTO> SeriesRatings { get; set; }
        public UserFavoriteMoviesWithCountDTO FavoriteMovies { get; set; }
        public UserFavoriteSeriesWithCountDTO FavoriteSeries { get; set; }
        public UserMovieCommentsWithCountDTO MovieComments { get; set; }
        public UserSerieCommentsWithCountDTO SerieComments { get; set; }
        public List<RequestDTO> Requests { get; set; }
    }
}