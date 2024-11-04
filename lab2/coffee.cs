namespace Coffee_types
{
    public class Coffee
    {
        public Intensity CoffeeIntensity { get; set; }
        public const string Name = "Coffee";

        public Coffee(Intensity intensity)
        {
            CoffeeIntensity = intensity;
        }

        public virtual void PrintCoffeeDetails()
        {
            Console.WriteLine($"Coffee Name: {Name}");
            Console.WriteLine($"Intensity: {CoffeeIntensity}");
        }
    }
}
