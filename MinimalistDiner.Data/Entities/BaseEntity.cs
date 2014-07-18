using System;

namespace MinimalistDiner.Data.Entities
{
    public abstract class BaseEntity 
    {
        public virtual Guid Id { get; set; }
    }
}
