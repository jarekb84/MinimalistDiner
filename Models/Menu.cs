using System.Collections.Generic;
using MinimalistDiner.Enums;

namespace MinimalistDiner.Models
{
    class Menu
    {
        public string Name { get; set; }
        public MenuType Type { get; set; }
        public List<Dish> Dishes { get; set; }

        public Menu()
        {
            Dishes = new List<Dish>();
        }
    }
}
