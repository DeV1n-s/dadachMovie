using System;
using System.Text.Json.Serialization;

namespace dadachMovie.DTOs
{
    public class CommentCreationDTO
    {
        [JsonIgnore]
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string Content { get; set; }
    }
}