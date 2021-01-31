using System;
using System.Text.Json.Serialization;

namespace dadachMovie.DTOs
{
    public class CommentCreationDTO
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        [JsonIgnore]
        public int? Type { get; set; }
        public int? MovieId { get; set; }
        public int? SerieId { get; set; }
        public string Content { get; set; }
    }
}