using Newtonsoft.Json;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string folderPath = @"queue";
        var carQueue = new ArrayQueue<Car>(10);

        var electricStation = new ElectricStation();
        var gasStation = new GasStation();
        var peopleDinner = new PeopleDinner();
        var robotDinner = new RobotDinner();

        var carStation = new CarStation(carQueue, electricStation, peopleDinner);

        foreach (var filePath in Directory.GetFiles(folderPath, "*.json"))
        {
            var fileContent = File.ReadAllText(filePath);
            var car = JsonConvert.DeserializeObject<Car>(fileContent);
            carStation.AddCar(car);
        }

        carStation.ServeCars();

        var newCar = new Car(4, "ELECTRIC", "ROBOTS", true, 123);
        carStation.AddCar(newCar);

        Console.WriteLine("Processing new car...");
        carStation.ServeCars();

        var gasCarStation = new CarStation(carQueue, gasStation, robotDinner);
        Console.WriteLine("Processing gas cars...");
        gasCarStation.ServeCars();
    }
}
