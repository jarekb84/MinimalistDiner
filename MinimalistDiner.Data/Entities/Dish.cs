namespace MinimalistDiner.Data.Entities
{
    public class Dish: BaseEntity
    {
        public string Value { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool IsMultipleAllowed { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
