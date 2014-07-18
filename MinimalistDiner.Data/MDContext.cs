using System;
using System.Data.Entity;
using System.Linq;
using MinimalistDiner.Data.Entities;

namespace MinimalistDiner.Data
{
    public class MDContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added && e.Entity.Id == Guid.Empty))
            {
                entry.Entity.Id = Guid.NewGuid();
            }
            
            return base.SaveChanges();
        }
    }
}
