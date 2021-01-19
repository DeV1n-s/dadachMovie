namespace dadachMovie.Enums
{
    public enum MoviesRatingSaveValidationResult
    {
        OK = 1,
        NullRating = 2,
        InvalidUserId = 3,
        UserNotFound = 4,
        InvalidMovieId = 5,
        MovieNotFound = 6
    }
}