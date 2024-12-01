public class CarStation
{
    private ArrayQueue<Car> _carQueue;
    private IRefuelable _refuelService;
    private IDineable _dineService;

    public CarStation(ArrayQueue<Car> carQueue, IRefuelable refuelService, IDineable dineService)
    {
        _carQueue = carQueue;
        _refuelService = refuelService;
        _dineService = dineService;
    }

    public void ServeCars()
    {
        while (!_carQueue.IsEmpty())
        {
            var car = _carQueue.Dequeue();

            if (car.Type == "ELECTRIC")
            {
                _refuelService = new ElectricStation();
                _refuelService.Refuel(car.Id);
                Console.WriteLine($"Car {car.Id} is an Electric car and is being refueled at the Electric Station.");
            }
            else if (car.Type == "GAS")
            {
                _refuelService = new GasStation();
                _refuelService.Refuel(car.Id);
                Console.WriteLine($"Car {car.Id} is a Gas car and is being refueled at the Gas Station.");
            }

            if (car.IsDining)
            {
                if (car.Passengers == "PEOPLE")
                {
                    _dineService.ServeDinner(car.Id);
                    Console.WriteLine($"Dinner is being served to the passengers of car {car.Id} (People).");
                }
                else if (car.Passengers == "ROBOTS")
                {
                    _dineService.ServeDinner(car.Id);
                    Console.WriteLine($"Dinner is being served to the passengers of car {car.Id} (Robots).");
                }
            }
            else
            {
                Console.WriteLine($"Car {car.Id} does not need dinner.");
            }

            Console.WriteLine($"Car {car.Id} of type {car.Type} has been processed.");
        }
    }

    public void AddCar(Car car)
    {
        _carQueue.Enqueue(car);
        Console.WriteLine($"Car {car.Id} added to the station queue.");
    }
}
