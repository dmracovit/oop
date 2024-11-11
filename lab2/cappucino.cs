namespace Coffee_types
{
    public class Cappuccino : Coffee
    {
        protected int MlOfMilk;
        private const string Name = "Cappuccino";

        public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
        {
            MlOfMilk = mlOfMilk;
        }

        public override void Make()
        {
            Console.WriteLine($"Making a {Intensity} {Name}...");
            Console.WriteLine("1. Brew espresso.");
            Console.WriteLine($"2. Heat {MlOfMilk}ml of milk and froth it.");
            Console.WriteLine("3. Combine espresso with frothed milk.");
            Console.WriteLine("Your Cappuccino is ready!\n");
        }

    }
}
