using System;
using System.Collections.Generic;
using System.Linq;
using MinimalistDiner.Models;
using MinimalistDiner.Services;

namespace MinimalistDiner
{
    class Program
    {
        static void Main(string[] args)
        {   
            var _menuService = new MenuService();
            
            if (args.Any())
            {
                var selectedMenu = _menuService.Menus.FirstOrDefault(m => m.Name == args[0].TrimEnd(',').ToLower());

                if (selectedMenu == null)
                {
                    PrintOutput();
                    return;
                }

                var customerOrder = new List<Dish>();
                Dish selectedDish;

                for (int i = 1; i < args.Count(); i++)
                {
                    selectedDish = selectedMenu.Dishes.FirstOrDefault(d => d.Value == args[i].TrimEnd(','));
                        
                    if (selectedDish == null)
                    {
                        continue;
                    }

                    if (selectedDish.QuantityOrdered == 0)
                    {
                        selectedDish.QuantityOrdered++;
                        customerOrder.Add(selectedDish);
                    }
                    else if (selectedDish.IsMultipleAllowed)
                    {
                        selectedDish.QuantityOrdered++;
                    }
                }
                
                PrintOutput(selectedMenu, customerOrder);
            }
        }

        private static void PrintOutput(Menu menu = null, List<Dish> customerOrder = null)
        {
            var output = "";

            if (menu == null)
            {
                output += "Menu not found! ";
            }

            if (customerOrder == null || !customerOrder.Any())
            {
                output += "Dishes entered not found! ";
            }
            else
            {
                foreach (var dish in customerOrder.OrderBy(d => d.Priority))
                {
                    var multiple = "";
                    if (dish.QuantityOrdered > 1)
                    {
                        multiple = string.Format("(x{0})", dish.QuantityOrdered);
                    }
                    output += string.Format("{0}{1}, ", dish.Name, multiple);
                }    
            }

            Console.WriteLine("{0}", output.Trim().TrimEnd(','));
            Console.ReadLine();
        }
    }
}
