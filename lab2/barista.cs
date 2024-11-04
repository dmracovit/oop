using System.Collections.Generic;
using Coffee_types;
namespace CoffeeApp
{
    public class Barista
    {
        public void MakeCoffee(List<string> coffeeOrders, string intensityInput, string syrupType)
        {
            foreach (var coffeeType in coffeeOrders)
            {
                Coffee coffee = CreateCoffee(coffeeType, intensityInput, syrupType);
                if (coffee != null)
                {
                    coffee.Make();
                }
                else
                {
                    Console.WriteLine($"Unknown coffee type: {coffeeType}");
                }
            }
        }

        private Coffee CreateCoffee(string coffeeType, string intensityInput, string syrupType)
        {
            return coffeeType switch
            {
                "Americano" => new Americano((Intensity)Enum.Parse(typeof(Intensity), intensityInput), 150),
                "Cappuccino" => new Cappuccino((Intensity)Enum.Parse(typeof(Intensity), intensityInput), 100),
                "SyrupCappuccino" => new SyrupCappuccino((Intensity)Enum.Parse(typeof(Intensity), intensityInput), 100, (SyrupType)Enum.Parse(typeof(SyrupType), syrupType)),
                "PumpkinSpiceLatte" => new PumpkinSpiceLatte((Intensity)Enum.Parse(typeof(Intensity), intensityInput), 120, 50),
                _ => null
            };
        }
    }
}
