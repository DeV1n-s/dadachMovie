using System;
using System.ComponentModel.DataAnnotations.Schema;
using dadachMovie.Enums;

namespace dadachMovie.Entities
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            
        }
        
        public int Id { get; set; }
        public string Content { get; set; }
        public CommentType Type { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
        public int? MovieId { get; set; }

        [ForeignKey(nameof(SerieId))]
        public Serie Serie { get; set; }
        public int? SerieId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}