using System;

namespace dadachMovie.Entities
{
    public abstract class BaseEntity
 {
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
 }
}