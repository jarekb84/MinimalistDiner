using System;
using System.Collections.Generic;
using System.Linq;
using MinimalistDiner.Models;
using MinimalistDiner.Services;

namespace MinimalistDiner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var order = new OrderingService(args);

            Console.WriteLine(order.Result);
            Console.ReadKey();
        }
    }
}