namespace dadachMovie.DTOs
{
    public class SerieCommentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SerieId { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
    }
}