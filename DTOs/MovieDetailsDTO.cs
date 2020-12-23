using System.Collections.Generic;
using dadachMovie.Entities;

namespace dadachMovie.DTOs
{
    public class MovieDetailsDTO : MovieDTO
    {
        public List<GenreDTO> Genres { get; set; }
        public List<CastDTO> Casts { get; set; }
        public List<DirectorDTO> Directors { get; set; }
    }
}