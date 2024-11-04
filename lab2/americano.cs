namespace Coffee_types
{
    public class Americano : Coffee
    {
        public int MlOfWater { get; set; }
        public new const string Name = "Americano";

        public Americano(Intensity intensity, int mlOfWater) : base(intensity)
        {
            MlOfWater = mlOfWater;
        }

        public override void PrintCoffeeDetails()
        {
            base.PrintCoffeeDetails();
            Console.WriteLine($"Water Volume: {MlOfWater}ml");
        }
    }
}
