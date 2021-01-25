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
        public float ImdbRate { get; set; }
        public int ImdbRatesCount { get; set; }
        public float MetacriticRate { get; set; }
        public double AverageUserRate { get; set; }
        public int TotalUserRatesCount { get; set; }
        public int Lenght { get; set; }
        public bool InTheaters { get; set; }
        public string ImdbId { get; set; }
        public string Picture { get; set; }
        public string CreatedAt { get; set; }
    }
}