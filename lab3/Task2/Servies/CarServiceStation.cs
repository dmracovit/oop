public class CarServiceStation
{
    private ArrayQueue<Car> _carQueue;
    private IRefuelable _refuelService;
    private IDineable _dineService;

    public CarServiceStation(ArrayQueue<Car> carQueue, IRefuelable refuelService, IDineable dineService)
    {
        _carQueue = carQueue;
        _refuelService = refuelService;
        _dineService = dineService;
    }

    public void ProcessCars()
    {
        while (!_carQueue.IsEmpty())
        {
            var car = _carQueue.Dequeue(); 

            if (car.Type == "ELECTRIC")
            {
                _refuelService = new ElectricStation();
                _refuelService.Refuel(car.Id);  
            }
            else if (car.Type == "GAS")
            {
                _refuelService = new GasStation();
                _refuelService.Refuel(car.Id);  
            }

            if (car.IsDining)
            {
                if (car.Passengers == "PEOPLE")
                {
                    _dineService.ServeDinner(car.Id);  
                }
                else if (car.Passengers == "ROBOTS")
                {
                    _dineService.ServeDinner(car.Id); 
                }
            }
            else
            {
                Console.WriteLine($"Car {car.Id} does not need dinner.");
            }

            Console.WriteLine($"Car {car.Id} of type {car.Type} has been processed.");
        }
    }
}
