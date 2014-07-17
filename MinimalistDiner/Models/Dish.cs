using MinimalistDiner.Common;
using MinimalistDiner.Enums;

namespace MinimalistDiner.Models
{
    public class Dish : ContainsError
    {
        public string Value { get; set; }
        public string Name { get; set; }
        public DishType Type { get; set; }
        public int Priority { get; set; }
        public bool IsMultipleAllowed { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
