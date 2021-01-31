using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace dadachMovie.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            MoviesRatings = new List<MoviesRating>();
            FavoriteMovies = new List<Movie>();
            FavoriteSeries = new List<Serie>();
            Comments = new List<Comment>();
            Requests = new List<Request>();
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; } = "http://localhost:5000/users/default.png";
        public string BannerPicture { get; set; } = "http://localhost:5000/users/defaultbanner.png";

        [Column(TypeName = "date")]
        public DateTime? BirthDay { get; set; }
        public DateTime? RegisterDate { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
        public int? CountryId { get; set; }

        public virtual ICollection<MoviesRating> MoviesRatings { get; set; }
        public virtual ICollection<Movie> FavoriteMovies { get; set; }
        public virtual ICollection<Serie> FavoriteSeries { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}