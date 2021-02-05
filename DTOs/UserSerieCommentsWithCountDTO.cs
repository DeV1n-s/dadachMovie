using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class UserSerieCommentsWithCountDTO
    {
        public int TotalItems { get; set; }
        public List<UserSerieCommentDTO> Items { get; set; }
    }
}