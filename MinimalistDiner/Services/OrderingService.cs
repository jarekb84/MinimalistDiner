using System.Collections.Generic;
using System.Linq;
using MinimalistDiner.Models;

namespace MinimalistDiner.Services
{
    public class OrderingService
    {
        public string Result;

        public OrderingService(string[] args)
        {
            TakeOrder(args);
        }

        private void TakeOrder(string[] args)
        {
            var _menuService = new MenuService();
            Menu selectedMenu = null;
            var customerOrder = new List<Dish>();

            if (args.Any())
            {
                selectedMenu = _menuService.Menus.FirstOrDefault(m => m.Name == args[0].TrimEnd(',').ToLower());

                if (selectedMenu == null)
                {
                    PrintOutput();
                }

                Dish selectedDish;

                for (int i = 1; i < args.Count(); i++)
                {
                    selectedDish = selectedMenu.Dishes.FirstOrDefault(d => d.Value == args[i].TrimEnd(','));

                    if (selectedDish == null)
                    {
                        selectedDish = customerOrder.Last();
                        selectedDish.HasError = true;
                        selectedDish.ErrorMessage = "error";

                        break;
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
                    else
                    {
                        selectedDish.HasError = true;
                        selectedDish.ErrorMessage = "error";
                    }
                }
            }
            PrintOutput(selectedMenu, customerOrder);
        }

        private void PrintOutput(Menu menu = null, List<Dish> customerOrder = null)
        {
            var output = "";
            if (menu == null)
            {
                Result = "error";
                return;
            }

            if (customerOrder == null || !customerOrder.Any())
            {
                Result = "error";
                return;
            }
            
            foreach (var dish in customerOrder.OrderBy(d => d.Priority))
            {
                var multiple = "";

                if (dish.QuantityOrdered > 1)
                {
                    multiple = string.Format("(x{0})", dish.QuantityOrdered);
                }
                
                output += string.Format("{0}{1}, {2}", dish.Name, multiple, dish.ErrorMessage);
                
                if (dish.HasError)
                {
                    break;
                }
                
            }    
            
            Result = string.Format("{0}", output.Trim().TrimEnd(','));
        }
    }
}
