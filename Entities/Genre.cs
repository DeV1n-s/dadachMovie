using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dadachAPI.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }
        public List<MoviesGenres> Genres { get; set; }
    }
}