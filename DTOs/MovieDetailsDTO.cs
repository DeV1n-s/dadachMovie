using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class MovieDetailsDTO : MovieDTO
    {
        public List<CommentDTO> Comments { get; set; }
    }
}