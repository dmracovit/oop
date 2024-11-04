using Coffee_types;

namespace Coffee_types
{
    public class Cappuccino : Coffee
    {
        protected int MlOfMilk;
        public new const string Name = "Cappuccino";

        public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
        {
            MlOfMilk = mlOfMilk;
        }

        public Cappuccino MakeCappuccino()
        {
            Console.WriteLine($"Making a {Name}...");
            Console.WriteLine($"1. Brew espresso.");
            Console.WriteLine($"2. Heat {MlOfMilk}ml of milk and froth it.");
            Console.WriteLine($"3. Combine espresso with frothed milk.");
            Console.WriteLine("Your Cappuccino is ready!\n");
            return this; 
        }

        public override void PrintCoffeeDetails()
        {
            base.PrintCoffeeDetails();
            Console.WriteLine($"Milk Volume: {MlOfMilk}ml");
        }
    }
}
