using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDatePersian { get; set; }
        public string ImdbRate { get; set; }
        public string ImdbRatesCount { get; set; }
        public string MetacriticRate { get; set; }
        public double AverageUserRate { get; set; }
        public int TotalUserRatesCount { get; set; }
        public int Lenght { get; set; }
        public bool InTheaters { get; set; }
        public string ImdbId { get; set; }
        public string Picture { get; set; }
        public string BannerImage { get; set; }
        public string CreatedAt { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<CastDTO> Casts { get; set; }
        public List<DirectorDTO> Directors { get; set; }
        public List<MoviesCountriesDTO> Countries { get; set; }
    }
}