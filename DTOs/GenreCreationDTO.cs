using System.ComponentModel.DataAnnotations;

namespace dadachAPI.DTOs
{
    public class GenreCreationDTO
    {
        [Required, StringLength(40)]
        public string Name { get; set; }
    }
}