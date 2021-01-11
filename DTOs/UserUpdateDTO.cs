using System.ComponentModel.DataAnnotations;

namespace dadachMovie.DTOs
{
    public class UserUpdateDTO
    {
        [Required]
        public string Id { get; set; }
        
        [Required, EmailAddress]
        public string CurrentEmailAddress { get; set; }

        [EmailAddress]
        public string NewEmailAddress { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
    }
}