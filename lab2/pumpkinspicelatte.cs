using Coffee_types;

namespace Coffee_types
{
    public class PumpkinSpiceLatte : Cappuccino
    {
        private int MgOfPumpkinSpice;
        public new const string Name = "PumpkinSpiceLatte";

        public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice) 
            : base(intensity, mlOfMilk)
        {
            MgOfPumpkinSpice = mgOfPumpkinSpice;
        }

        public PumpkinSpiceLatte MakePumpkinSpiceLatte()
        {
            Console.WriteLine($"Making a {Name}...");
            Console.WriteLine($"1. Brew espresso.");
            Console.WriteLine($"2. Heat {MlOfMilk}ml of milk and froth it.");
            Console.WriteLine($"3. Add {MgOfPumpkinSpice}mg of pumpkin spice.");
            Console.WriteLine($"4. Combine espresso, frothed milk, and pumpkin spice.");
            Console.WriteLine("Your Pumpkin Spice Latte is ready!\n");
            return this; 
        }

        public override void PrintCoffeeDetails()
        {
            base.PrintCoffeeDetails();
            Console.WriteLine($"Pumpkin Spice: {MgOfPumpkinSpice}mg");
        }
    }
}
