using System;
namespace dadachMovie.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortBio { get; set; }
        public string Biography { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsCast { get; set; }
        public bool IsDirector { get; set; }
        public string Picture { get; set; }
    }
}