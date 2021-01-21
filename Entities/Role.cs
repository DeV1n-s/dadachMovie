using System;
using Microsoft.AspNetCore.Identity;

namespace dadachMovie.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}