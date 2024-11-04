namespace Coffee_types
{
    public class SyrupCappuccino : Cappuccino
    {
        public SyrupType Syrup { get; set; }
        public new const string Name = "SyrupCappuccino";

        public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup) 
            : base(intensity, mlOfMilk)
        {
            Syrup = syrup;
        }

        public override void PrintCoffeeDetails()
        {
            base.PrintCoffeeDetails();
            Console.WriteLine($"Syrup Type: {Syrup}");
        }
    }
}
