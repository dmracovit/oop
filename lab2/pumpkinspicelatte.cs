namespace Coffee_types
{
    public class PumpkinSpiceLatte : Cappuccino
    {
        public int MgOfPumpkinSpice { get; set; }
        public new const string Name = "PumpkinSpiceLatte";

        public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice) 
            : base(intensity, mlOfMilk)
        {
            MgOfPumpkinSpice = mgOfPumpkinSpice;
        }

        public override void PrintCoffeeDetails()
        {
            base.PrintCoffeeDetails();
            Console.WriteLine($"Pumpkin Spice: {MgOfPumpkinSpice}mg");
        }
    }
}
