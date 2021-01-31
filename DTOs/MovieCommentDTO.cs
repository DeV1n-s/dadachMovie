namespace dadachMovie.DTOs
{
    public class MovieCommentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
    }
}