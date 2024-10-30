namespace CoffeeShop
{
    public class Cappuccino : Coffee
    {
        public int MlOfMilk { get; set; }
        public const string CoffeeType = "Cappuccino";

        public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
        {
            MlOfMilk = mlOfMilk;
        }

    }
}
