namespace Coffee_types
{
    public class SyrupCappuccino : Cappuccino
    {
        private SyrupType Syrup;
        private const string Name = "SyrupCappuccino";

        public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup) 
            : base(intensity, mlOfMilk)
        {
            Syrup = syrup;
        }

        public override void Make()
        {
            Console.WriteLine($"Making a {Intensity} {Name}...");
            Console.WriteLine($"1. Brew espresso.");
            Console.WriteLine($"2. Heat {MlOfMilk}ml of milk and froth it.");
            Console.WriteLine($"3. Add syrup flavor: {Syrup}.");
            Console.WriteLine($"4. Combine espresso, frothed milk, and syrup.");
            Console.WriteLine("Your Syrup Cappuccino is ready!\n");
        }
    }
}
