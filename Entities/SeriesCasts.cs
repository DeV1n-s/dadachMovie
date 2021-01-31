namespace dadachMovie.Entities
{
    public class SeriesCasts
    {
        public SeriesCasts()
        {
            
        }
        
        public int PersonId { get; set; }
        public int SerieId { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }

        public Person Person { get; set; }
        public Serie Serie { get; set; }
    }
}