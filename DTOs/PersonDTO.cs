using System.Collections.Generic;

namespace dadachMovie.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortBio { get; set; }
        public string Biography { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfBirthPersian { get; set; }
        public string Picture { get; set; }
        public string CountryName { get; set; }
        public string Nationality { get; set; }
        public List<string> Categories { get; set; }
    }
}