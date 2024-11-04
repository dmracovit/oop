namespace Coffee_types
{
    public class Cappuccino : Coffee
    {
        public int MlOfMilk { get; set; }
        public new const string Name = "Cappuccino";

        public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
        {
            MlOfMilk = mlOfMilk;
        }

        public override void PrintCoffeeDetails()
        {
            base.PrintCoffeeDetails();
            Console.WriteLine($"Milk Volume: {MlOfMilk}ml");
        }
    }
}
