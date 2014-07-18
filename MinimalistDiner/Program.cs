using System;
using System.Linq;
using MinimalistDiner.Data.Entities;
using MinimalistDiner.Services;


namespace MinimalistDiner
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            using (MinimalistDiner.Data.MDContext db = new MinimalistDiner.Data.MDContext())
            {
                var test = db.Menus.ToList();

                db.Menus.Add(new Menu() {Name = "test"});
                db.SaveChanges();
            }
            var order = new OrderingService(args);

            Console.WriteLine(order.Result);
            Console.ReadKey();
        }
    }
}