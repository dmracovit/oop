using Coffee_types;

namespace Coffee_types
{
    public class Americano : Coffee
    {
        private int MlOfWater;
        public new const string Name = "Americano";

        public Americano(Intensity intensity, int mlOfWater) : base(intensity)
        {
            MlOfWater = mlOfWater;
        }

        public Americano MakeAmericano()
        {
            Console.WriteLine($"Making a {Name}...");
            Console.WriteLine($"1. Brew espresso.");
            Console.WriteLine($"2. Add {MlOfWater}ml of hot water.");
            Console.WriteLine("Your Americano is ready!\n");
            return this; 
        }

        public override void PrintCoffeeDetails()
        {
            base.PrintCoffeeDetails();
            Console.WriteLine($"Water Volume: {MlOfWater}ml");
        }
    }
}
