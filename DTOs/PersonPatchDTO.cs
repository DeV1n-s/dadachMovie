using System;
using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class PersonPatchDTO
    {
        [Required, MaxLength(120)]
        public string Name { get; set; }
        public string ShortBio { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsCast { get; set; }
        public bool IsDirector { get; set; }
    }
}