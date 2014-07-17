using System.Collections.Generic;
using MinimalistDiner.Enums;
using MinimalistDiner.Common;

namespace MinimalistDiner.Models
{
    public class Menu:  ContainsError
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
