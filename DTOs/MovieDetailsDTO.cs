using System.Collections.Generic;

namespace dadachAPI.DTOs
{
    public class MovieDetailsDTO : MovieDTO
    {
        public List<GenreDTO> Genres { get; set; }
        public List<CasterDTO> Casters { get; set; }
        public List<PersonDTO> Directors { get; set; }
    }
}