using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dadachMovie.Entities
{
    public class Genre
    {
        public Genre()
        {
            Movies = new List<Movie>();
            Series = new List<Serie>();
        }
        
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }
        
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
    }
}