using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class MovieDetailsDTO : MovieDTO
    {
        public List<MovieCommentDTO> Comments { get; set; }
    }
}