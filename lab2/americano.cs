namespace Coffee_types
{
    public class Americano : Coffee
    {
        private int MlOfWater;
        private const string Name ="Americano";

        public Americano(Intensity intensity, int mlOfWater) : base(intensity)
        {
            MlOfWater = mlOfWater;
        }

        public override void Make()
        {
            Console.WriteLine($"Making a {Intensity} {Name}...");
            Console.WriteLine("1. Brew espresso.");
            Console.WriteLine($"2. Add {MlOfWater}ml of hot water.");
            Console.WriteLine("Your Americano is ready!\n");
        }

    }
}
