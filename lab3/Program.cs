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

        var carStation = new CarStation(carQueue, electricStation, peopleDinner); 

        // Обрабатываем уже существующие машины в папке
        ProcessExistingCars(folderPath, carStation);

        // Настроим FileSystemWatcher для отслеживания появления новых машин в папке
        FileSystemWatcher watcher = new FileSystemWatcher
        {
            Path = folderPath,
            Filter = "*.json", // Фильтруем только JSON файлы
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
        };

        // Обработчик события при создании нового файла
        watcher.Created += (sender, e) => OnChanged(sender, e, carStation);

        // Начинаем отслеживать папку
        watcher.EnableRaisingEvents = true;

        // Ожидаем, чтобы программа продолжала работать
        Console.WriteLine("Monitoring folder for new files. Press [Enter] to exit...");
        Console.ReadLine();
    }

    private static void OnChanged(object sender, FileSystemEventArgs e, CarStation carStation)
    {
        // Обрабатываем только созданные или измененные файлы
        if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
        {
            Console.WriteLine($"New file detected: {e.Name} ({e.ChangeType})");

            try
            {
                // Чтение содержимого файла и десериализация в объект Car
                string content = File.ReadAllText(e.FullPath);
                var car = JsonConvert.DeserializeObject<Car>(content);
                carStation.AddCar(car); // Добавляем машину в очередь

                // Обслуживаем машину
                carStation.ServeCars();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {e.Name}: {ex.Message}");
            }
        }
    }

    private static void ProcessExistingCars(string folderPath, CarStation carStation)
    {
        // Обрабатываем все машины, которые уже есть в папке при запуске программы
        foreach (var filePath in Directory.GetFiles(folderPath, "*.json"))
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                var car = JsonConvert.DeserializeObject<Car>(fileContent);
                carStation.AddCar(car); // Добавляем машину в очередь
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file {filePath}: {ex.Message}");
            }
        }

        carStation.ServeCars();
    }
}
