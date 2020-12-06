using System;
using System.ComponentModel.DataAnnotations;

namespace dadachAPI.DTOs
{
    public class MoviePatchDTO
    {
        public string Title { get; set; }
        public string ShortPara { get; set; }
        public string LongPara { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rate { get; set; }
        public bool InTheaters { get; set; }
    }
}