using System;
using CoffeeShop; 

class Program
{
    static void Main(string[] args)
    {
        Barista barista = new Barista();

        barista.MakeAmericano(Coffee_types.Intensity.NORMAL, 200);

        barista.MakeCappuccino(Coffee_types.Intensity.STRONG, 150);

        barista.MakePumpkinSpiceLatte(Coffee_types.Intensity.NORMAL, 150, 10);

        barista.MakeSyrupCappuccino(Coffee_types.Intensity.STRONG, 150, Coffee_types.SyrupType.VANILLA);

        Console.WriteLine("All coffees have been prepared.");
    }
}
