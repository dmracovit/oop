namespace CoffeeShop
{
    public class Barista
    {
        public Coffee MakeCoffee(Intensity intensity)
        {
            return new Coffee(intensity);
        }

        public Cappuccino MakeCappuccino(Intensity intensity, int mlOfMilk)
        {
            return new Cappuccino(intensity, mlOfMilk);
        }

        public Americano MakeAmericano(Intensity intensity, int mlOfWater)
        {
            return new Americano(intensity, mlOfWater);
        }

        public PumpkinSpiceLatte MakePumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
        {
            return new PumpkinSpiceLatte(intensity, mlOfMilk, mgOfPumpkinSpice);
        }

        public SyrupCappuccino MakeSyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup)
        {
            return new SyrupCappuccino(intensity, mlOfMilk, syrup);
        }
    }
}
