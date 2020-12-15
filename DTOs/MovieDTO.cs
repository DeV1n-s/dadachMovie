using System;

namespace dadachMovie.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Rate { get; set; }
        public bool InTheaters { get; set; }
        public string Picture { get; set; }
    }
}