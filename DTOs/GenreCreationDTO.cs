using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class GenreCreationDTO
    {
        [Required, StringLength(40)]
        public string Name { get; set; }
    }
}