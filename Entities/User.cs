using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace dadachMovie.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country Country { get; set; }
        public string Picture { get; set; } = "http://localhost:5000/users/default.png";
        public DateTimeOffset RegisterDate { get; set; }

        public virtual ICollection<MoviesRating> MoviesRatings { get; set; }
        public virtual ICollection<Movie> FavoriteMovies { get; set; } = new List<Movie>();
    }
}