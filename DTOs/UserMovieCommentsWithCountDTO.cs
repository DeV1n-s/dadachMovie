using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class UserMovieCommentsWithCountDTO
    {
        public int TotalItems { get; set; }
        public List<UserMovieCommentDTO> Items { get; set; }
    }
}