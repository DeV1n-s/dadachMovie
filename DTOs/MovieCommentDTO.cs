namespace dadachMovie.DTOs
{
    public class MovieCommentDTO
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string UserPicture { get; set; }
        public int UserRate { get; set; }
        public int MovieId { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
    }
}