using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class MovieDetailsDTO : MovieDTO
    {
        public double AverageUserRate { get; set; }
        public int TotalUserRatesCount { get; set; }
        
        public List<GenreDTO> Genres { get; set; }
        public List<CastDTO> Casts { get; set; }
        public List<DirectorDTO> Directors { get; set; }
        public List<string> Countries { get; set; }
    }
}