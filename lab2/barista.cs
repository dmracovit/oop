using Coffee_types;

namespace CoffeeShop
{
    public class Barista
    {
        public Cappuccino MakeCappuccino(Intensity intensity, int mlOfMilk)
        {
            return new Cappuccino(intensity, mlOfMilk).MakeCappuccino();
        }

        public PumpkinSpiceLatte MakePumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
        {
            return new PumpkinSpiceLatte(intensity, mlOfMilk, mgOfPumpkinSpice).MakePumpkinSpiceLatte();
        }

        public Americano MakeAmericano(Intensity intensity, int mlOfWater)
        {
            return new Americano(intensity, mlOfWater).MakeAmericano();
        }

        public SyrupCappuccino MakeSyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup)
        {
            return new SyrupCappuccino(intensity, mlOfMilk, syrup).MakeSyrupCappuccino();
        }
    }
}
