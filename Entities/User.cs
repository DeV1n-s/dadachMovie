using Microsoft.AspNetCore.Identity;

namespace dadachMovie.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country Country { get; set; }
    }
}