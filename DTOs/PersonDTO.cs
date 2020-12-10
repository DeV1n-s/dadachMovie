using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using dadachMovie.Entities;
using Newtonsoft.Json.Converters;

namespace dadachMovie.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortBio { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Picture { get; set; }
    }
}