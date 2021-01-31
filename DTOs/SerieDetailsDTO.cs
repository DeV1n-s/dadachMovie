using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class SerieDetailsDTO : SerieDTO
    {
        public List<SerieCommentDTO> Comments { get; set; }
    }
}