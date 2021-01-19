namespace dadachMovie.Entities
{
    public class MoviesCountries
    {
        public int MovieId { get; set; }
        public int CountryId { get; set; }
        
        public Movie Movie { get; set; }
        public Country Country { get; set; }
    }
}