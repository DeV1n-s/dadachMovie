using System;
using System.Text.Json.Serialization;

namespace dadachMovie.DTOs
{
    public class RequestCreationDTO
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}