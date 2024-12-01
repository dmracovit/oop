using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        // Указываем путь к папке, где находятся файлы с данными машин
        string folderPath = @"queue"; // Измените на нужный путь

        // Создаем очередь с размером 10 (или можно сделать без ограничения)
        var carQueue = new ArrayQueue<Car>(10);

        // Читаем все файлы в папке
        foreach (var filePath in Directory.GetFiles(folderPath, "*.json"))
        {
            // Читаем содержимое каждого файла
            var fileContent = File.ReadAllText(filePath);

            // Парсим JSON в объект Car
            var car = JsonConvert.DeserializeObject<Car>(fileContent);  // Используем JsonConvert

            // Добавляем объект Car в очередь
            carQueue.Enqueue(car);
        }

        // Создаем экземпляры сервисов для заправки и ужина
        var electricStation = new ElectricStation();
        var gasStation = new GasStation();
        var peopleDinner = new PeopleDinner();
        var robotDinner = new RobotDinner();

        // Создаем экземпляр CarServiceStation и передаем очередь и сервисы для машин типа "ELECTRIC"
        var electricCarServiceStation = new CarServiceStation(carQueue, electricStation, peopleDinner);
        electricCarServiceStation.ProcessCars();

        // Создаем экземпляр CarServiceStation и передаем очередь и сервисы для машин типа "GAS"
        var gasCarServiceStation = new CarServiceStation(carQueue, gasStation, robotDinner);
        gasCarServiceStation.ProcessCars();
    }
}
