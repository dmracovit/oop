namespace CoffeeShop
{
    public class SyrupCappuccino : Cappuccino
    {
        public SyrupType Syrup { get; set; }
        public new const string CoffeeType = "SyrupCappuccino";

        public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup) : base(intensity, mlOfMilk)
        {
            Syrup = syrup;
        }

    }
}
