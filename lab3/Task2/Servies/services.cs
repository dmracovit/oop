public class ElectricStation : IRefuelable
{
    public void Refuel(int carId)
    {
        Console.WriteLine($"Refueling electric car {carId}.");
    }
}


public class GasStation : IRefuelable
{
    public void Refuel(int carId)
    {
        Console.WriteLine($"Refueling gas car {carId}.");
    }
}


public class PeopleDinner : IDineable
{
    public void ServeDinner(int carId)
    {
        Console.WriteLine($"Serving dinner to people in car {carId}.");
    }
}


public class RobotDinner : IDineable
{
    public void ServeDinner(int carId)
    {
        Console.WriteLine($"Serving dinner to robots in car {carId}.");
    }
}

