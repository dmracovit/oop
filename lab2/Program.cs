using System;
using System.Collections.Generic;

namespace CoffeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the type of coffee you want (e.g., Americano, Cappuccino, SyrupCappuccino, PumpkinSpiceLatte):");
            string coffeeType = Console.ReadLine();

            Console.WriteLine("Enter the intensity (LIGHT, NORMAL, STRONG):");
            string intensityInput = Console.ReadLine().ToUpper();
            while (intensityInput != "LIGHT" && intensityInput != "NORMAL" && intensityInput != "STRONG")
            {
                Console.WriteLine("Invalid intensity. Please enter LIGHT, NORMAL, or STRONG:");
                intensityInput = Console.ReadLine().ToUpper();
            }

            string syrupType = null;
            if (coffeeType == "SyrupCappuccino")
            {
                Console.WriteLine("Enter the syrup type (MACADAMIA, VANILLA, COCONUT, CARAMEL, CHOCOLATE, POPCORN):");
                syrupType = Console.ReadLine().ToUpper();
                while (syrupType != "MACADAMIA" && syrupType != "VANILLA" && syrupType != "COCONUT" && 
                       syrupType != "CARAMEL" && syrupType != "CHOCOLATE" && syrupType != "POPCORN")
                {
                    Console.WriteLine("Invalid syrup type. Please enter a valid syrup type:");
                    syrupType = Console.ReadLine().ToUpper();
                }
            }

            List<string> coffeeOrders = new List<string> { coffeeType };

            Barista barista = new Barista();
            barista.MakeCoffee(coffeeOrders, intensityInput, syrupType);
        }
    }
}
