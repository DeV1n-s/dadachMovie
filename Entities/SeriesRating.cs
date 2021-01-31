using System;

namespace dadachMovie.Entities
{
    public class SeriesRating
    {
        public SeriesRating()
        {
            
        }
        public Guid UserId { get; set; }
        public int SerieId { get; set; }
        public int Rate { get; set; }

        public Serie Serie { get; set; }
        public User User { get; set; }
    }
}