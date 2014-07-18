using System.Collections.Generic;

namespace MinimalistDiner.Data.Entities
{
    public class Menu: BaseEntity
    {
        public string Name { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
