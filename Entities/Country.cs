using System.Collections.Generic;

namespace dadachMovie.Entities
{
    public class Country
    {
        public Country()
        {
            Users = new List<User>();
            People = new List<Person>();
            Movies = new List<Movie>();
            Series = new List<Serie>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Name_FA { get; set; }
        public string Nationality_FA { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
    }
}