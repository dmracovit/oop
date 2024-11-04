using Coffee_types;

namespace Coffee_types
{
    public class SyrupCappuccino : Cappuccino
    {
        private SyrupType Syrup;
        public new const string Name = "SyrupCappuccino";

        public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup) 
            : base(intensity, mlOfMilk)
        {
            Syrup = syrup;
        }

        public SyrupCappuccino MakeSyrupCappuccino()
        {
            Console.WriteLine($"Making a {Name}...");
            Console.WriteLine($"1. Brew espresso.");
            Console.WriteLine($"2. Heat {MlOfMilk}ml of milk and froth it.");
            Console.WriteLine($"3. Add syrup flavor: {Syrup}.");
            Console.WriteLine($"4. Combine espresso, frothed milk, and syrup.");
            Console.WriteLine("Your Syrup Cappuccino is ready!\n");
            return this; 
        }

        public override void PrintCoffeeDetails()
        {
            base.PrintCoffeeDetails();
            Console.WriteLine($"Syrup: {Syrup}");
        }
    }
}
