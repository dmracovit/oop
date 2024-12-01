using System;
using System.IO;
using Newtonsoft.Json;



class Program
{
    static void Main(string[] args)
    {
        string folderPath = "queue"; // Set folder path here
        IQueue<Car> carQueue = new LinkedListQueue<Car>(); // Or use ArrayQueue<Car>();

        // Read all JSON files from the folder and add to the queue
        LoadCarsFromFolder(folderPath, carQueue);

        // Print the size of the queue
        Console.WriteLine($"Cars in the queue: {carQueue.Size()}");

        // Dequeue and print some cars
        if (!carQueue.IsEmpty())
        {
            var car = carQueue.Dequeue();
            Console.WriteLine($"Dequeued car: {car.Id} - {car.Type}");
        }
    }

    static void LoadCarsFromFolder(string folderPath, IQueue<Car> queue)
    {
        if (Directory.Exists(folderPath))
        {
            string[] files = Directory.GetFiles(folderPath, "*.json");
            foreach (var file in files)
            {
                try
                {
                    string jsonContent = File.ReadAllText(file);
                    var car = Car.FromJson(jsonContent);
                    queue.Enqueue(car);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading {file}: {ex.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine("Folder does not exist.");
        }
    }
}
