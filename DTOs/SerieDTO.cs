using System.Collections.Generic;
using dadachMovie.Enums;

namespace dadachMovie.DTOs
{
    public class SerieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? Seasons { get; set; }
        public int? Episodes { get; set; }
        public string Status { get; set; }
        public string AirDay { get; set; }
        public string ImdbRate { get; set; }
        public string ImdbRatesCount { get; set; }
        public string MetacriticRate { get; set; }
        public double AverageUserRate { get; set; }
        public int TotalUserRatesCount { get; set; }
        public int Lenght { get; set; }
        public string ImdbId { get; set; }
        public string Picture { get; set; }
        public string BannerImage { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<CastDTO> Casts { get; set; }
        public List<DirectorDTO> Directors { get; set; }
        public List<SeriesCountriesDTO> Countries { get; set; }
    }
}