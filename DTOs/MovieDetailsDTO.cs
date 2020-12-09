using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class MovieDetailsDTO : MovieDTO
    {
        public List<GenreDTO> Genres { get; set; }
        public List<CasterDTO> Casters { get; set; }
        public List<DirectorDTO> Directors { get; set; }
    }
}