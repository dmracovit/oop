using Newtonsoft.Json;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string folderPath = @"queue"; 
        var carQueue = new ArrayQueue<Car>(100);

        var electricStation = new ElectricStation();
        var gasStation = new GasStation();
        var peopleDinner = new PeopleDinner();
        var robotDinner = new RobotDinner();


        int maxConcurrentCars = 2;
        var semaphore = new Semaphore(2); 
        var carStation = new CarStation(carQueue, electricStation, peopleDinner, semaphore, maxConcurrentCars);

        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = folderPath;
        watcher.Filter = "*.json"; 
        watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

        watcher.Created += (sender, e) => OnNewFileAdded(e, carStation);
        watcher.Changed += (sender, e) => OnNewFileAdded(e, carStation);

        watcher.EnableRaisingEvents = true;

        ProcessExistingFiles(folderPath, carStation);

        Console.WriteLine("Started monitoring the folder for new cars...");
        Console.WriteLine("Press [Enter] to stop...");

        while (true)
        {
            carStation.ServeCars();
            System.Threading.Thread.Sleep(1000);
        }
    }

    private static void OnNewFileAdded(FileSystemEventArgs e, CarStation carStation)
    {
        try
        {
            Console.WriteLine($"New file detected: {e.Name}");
            string fileContent = File.ReadAllText(e.FullPath);
            var car = JsonConvert.DeserializeObject<Car>(fileContent);

            carStation.AddCar(car);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file {e.Name}: {ex.Message}");
        }
    }

    private static void ProcessExistingFiles(string folderPath, CarStation carStation)
    {
        foreach (var filePath in Directory.GetFiles(folderPath, "*.json"))
        {
            try
            {
                Console.WriteLine($"Processing existing file: {filePath}");
                string fileContent = File.ReadAllText(filePath);
                var car = JsonConvert.DeserializeObject<Car>(fileContent);

                carStation.AddCar(car);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing existing file {filePath}: {ex.Message}");
            }
        }
    }
}
