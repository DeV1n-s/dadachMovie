namespace dadachMovie.Entities
{
    public class MoviesRating
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public int Rate { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}