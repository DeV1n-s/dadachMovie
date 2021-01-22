namespace dadachMovie.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string Content { get; set; }
        public string DateAdded { get; set; }
    }
}