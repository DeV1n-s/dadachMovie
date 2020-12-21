namespace dadachMovie.Entities
{
    public class PeopleCountries
    {
        public int PersonId { get; set; }
        public int CountryId { get; set; }
        public Person Person { get; set; }
        public Country Country { get; set; }
    }
}