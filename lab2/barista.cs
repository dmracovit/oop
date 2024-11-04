using Coffee_types;  


    public class Barista
    {
        public Americano MakeAmericano(Intensity intensity, int mlOfWater)
        {
            Americano americano = new Americano(intensity, mlOfWater);
            PrepareCoffee(americano);
            return americano;
        }

        public Cappuccino MakeCappuccino(Intensity intensity, int mlOfMilk)
        {
            Cappuccino cappuccino = new Cappuccino(intensity, mlOfMilk);
            PrepareCoffee(cappuccino);
            return cappuccino;
        }

        public PumpkinSpiceLatte MakePumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
        {
            PumpkinSpiceLatte latte = new PumpkinSpiceLatte(intensity, mlOfMilk, mgOfPumpkinSpice);
            PrepareCoffee(latte);
            return latte;
        }

        public SyrupCappuccino MakeSyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup)
        {
            SyrupCappuccino syrupCappuccino = new SyrupCappuccino(intensity, mlOfMilk, syrup);
            PrepareCoffee(syrupCappuccino);
            return syrupCappuccino;
        }

        private void PrepareCoffee(Coffee coffee)
        {
            Console.WriteLine($"Preparing {coffee.GetType().Name}...");
            coffee.PrintCoffeeDetails();
            Console.WriteLine("Coffee is ready!\n");
        }
    }

