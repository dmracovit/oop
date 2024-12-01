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
            var car = _carQueue.Dequeue(); // Берем автомобиль из очереди

            // Выбираем сервис в зависимости от типа машины
            if (car.Type == "ELECTRIC")
            {
                // Электрические машины заправляются на электрической станции
                _refuelService = new ElectricStation();
                _refuelService.Refuel(car.Id);  // Обслуживаем заправку с использованием ID
            }
            else if (car.Type == "GAS")
            {
                // Бензиновые машины заправляются на газовой станции
                _refuelService = new GasStation();
                _refuelService.Refuel(car.Id);  // Обслуживаем заправку с использованием ID
            }

            // Обрабатываем ужин, если требуется
            if (car.IsDining)
            {
                if (car.Passengers == "PEOPLE")
                {
                    _dineService.ServeDinner(car.Id);  // Сервируем ужин людям
                }
                else if (car.Passengers == "ROBOTS")
                {
                    _dineService.ServeDinner(car.Id);  // Сервируем ужин роботам
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
