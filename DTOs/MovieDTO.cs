using System;

namespace dadachAPI.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortPara { get; set; }
        public string LongPara { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rate { get; set; }
        public bool InTheaters { get; set; }
        public string Picture { get; set; }
    }
}