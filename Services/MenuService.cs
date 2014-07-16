using System.Collections.Generic;
using MinimalistDiner.Enums;
using MinimalistDiner.Models;

namespace MinimalistDiner.Services
{
    class MenuService
    {
        public List<Menu> Menus { get; set; }

        public MenuService()
        {
            Menus = new List<Menu>();
            PopulateMenus();
        }
        
        private void PopulateMenus()
        {
            var morningMenu = new Menu { Name = "morning", Type = MenuType.Morning};

            morningMenu.Dishes.Add(new Dish { Name = "eggs", Value = "1", Type = DishType.Entrée, Priority = 1, IsMultipleAllowed = false});
            morningMenu.Dishes.Add(new Dish { Name = "Toast", Value = "2", Type = DishType.Side, Priority = 2, IsMultipleAllowed = false });
            morningMenu.Dishes.Add(new Dish { Name = "coffee", Value = "3", Type = DishType.Drink, Priority = 3, IsMultipleAllowed = true });
            
            Menus.Add(morningMenu);

            var nightMenu = new Menu { Name = "night", Type = MenuType.Night };

            nightMenu.Dishes.Add(new Dish { Name = "steak", Value = "1", Type = DishType.Entrée, Priority = 1, IsMultipleAllowed = false });
            nightMenu.Dishes.Add(new Dish { Name = "potato", Value = "2", Type = DishType.Side, Priority = 2, IsMultipleAllowed = true });
            nightMenu.Dishes.Add(new Dish { Name = "wine", Value = "3", Type = DishType.Drink, Priority = 3, IsMultipleAllowed = false });
            nightMenu.Dishes.Add(new Dish { Name = "cake", Value = "4", Type = DishType.Desert, Priority = 4, IsMultipleAllowed = true });
            
            Menus.Add(nightMenu);
        }
    }
}
