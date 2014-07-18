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

        /// <summary>
        /// Creates customer order based on user inputs and enforces quantity and availability rules
        /// </summary>
        /// <param name="args">list of command line arguments</param>
        private void TakeOrder(string[] args)
        {
            var _menuService = new MenuService();
            Menu selectedMenu = null;
            var customerOrder = new List<Dish>();

            args = ParseArgs(args);

            if (args.Any())
            {
                selectedMenu = _menuService.Menus.FirstOrDefault(m => m.Name == args[0]);

                if (selectedMenu == null)
                {
                    selectedMenu = new Menu {HasError = true, ErrorMessage = "error"};
                    SetResult(selectedMenu);
                    return;
                }

                Dish selectedDish;

                for (int i = 1; i < args.Count(); i++)
                {
                    selectedDish = selectedMenu.Dishes.FirstOrDefault(d => d.Value == args[i]);

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
            else
            {
                selectedMenu = new Menu {HasError = true, ErrorMessage = "error"};
            }
            
            SetResult(selectedMenu, customerOrder);
        }

        

        /// <summary>
        /// Loops through arguments array and splits out any items that weren't delimeted correctly
        /// </summary>
        /// <remarks>
        /// Console arguments are split by spaces so we want to account for the user 
        /// adding or not adding spaces between their comma delimited list of order selections
        /// </remarks>
        /// <param name="args">command line arguments</param>
        /// <returns>Cleaned up and split up list of command line arguments</returns>
        private string[] ParseArgs(string[] args)
        {
            var output = new List<string>();

            foreach (var s in args)
            {
                var values = s.Split(',');

                foreach (var v in values)
                {
                    if (v.Length > 0)
                    {
                        output.Add(v.ToLower().Trim());    
                    }
                }
            }

            return output.ToArray();
        }

        /// <summary>
        /// Creates output string based on customer order. Stops string construction when any errors found.
        /// </summary>
        /// <param name="menu">User selected menu</param>
        /// <param name="customerOrder">User selected dishes</param>
        private void SetResult(Menu menu, List<Dish> customerOrder = null)
        {
            var output = "";
            if (menu.HasError)
            {
                Result = menu.ErrorMessage;
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
