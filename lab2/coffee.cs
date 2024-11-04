using Coffee_types;

namespace Coffee_types
{
    public class Coffee
    {
        private Intensity Intensity;
        public const string Name = "Coffee";

        public Coffee(Intensity intensity)
        {
            Intensity = intensity;
        }

        public virtual void PrintCoffeeDetails()
        {
            Console.WriteLine($"Coffee: {Name}");
            Console.WriteLine($"Intensity: {Intensity}");
        }
    }
}
