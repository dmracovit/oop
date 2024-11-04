using System;
using Coffee_types; // Import the Coffee_types namespace

class Program
{
    static void Main(string[] args)
    {
        Barista barista = new Barista();

        barista.MakeAmericano(Intensity.LIGHT, 200);

        barista.MakeCappuccino(Intensity.LIGHT, 150);

        barista.MakePumpkinSpiceLatte(Intensity.LIGHT, 150, 10);

        barista.MakeSyrupCappuccino(Intensity.LIGHT, 150, SyrupType.VANILLA);

        Console.WriteLine("All coffees have been prepared.");
    }
}
