using System;
using System.ComponentModel.DataAnnotations.Schema;
using dadachMovie.Enums;

namespace dadachMovie.Entities
{
    public class Request : BaseEntity
    {
        public Request()
        {
            this.Status = RequestStatus.Waiting;
        }
        
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public RequestStatus Status { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Guid UserId{ get; set; }
    }
}