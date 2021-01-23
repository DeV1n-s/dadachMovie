using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace dadachMovie.Entities
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}