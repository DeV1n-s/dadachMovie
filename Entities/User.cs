using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace dadachMovie.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
        public int? CountryId { get; set; }
        public string Picture { get; set; } = "http://localhost:5000/users/default.png";
        public DateTimeOffset RegisterDate { get; set; }

        public virtual ICollection<MoviesRating> MoviesRatings { get; set; }
        public virtual ICollection<Movie> FavoriteMovies { get; set; } = new List<Movie>();
    }
}