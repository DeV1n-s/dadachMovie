using System;

namespace dadachMovie.DTOs
{
    public class CommentCreationDTO
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string Content { get; set; }
    }
}