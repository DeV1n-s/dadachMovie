using System;

namespace dadachMovie.Entities
{
    public class MoviesRating
    {
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
        public int Rate { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}