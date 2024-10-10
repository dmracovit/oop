using System;

namespace SimpleOOP
{
    // Define a Car class
    class Car
    {
        // Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        // Constructor
        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        // Method to display car details
        public void DisplayInfo()
        {
            Console.WriteLine($"Car Make: {Make}, Model: {Model}, Year: {Year}");
        }

        // Method to start the car
        public void Start()
        {
            Console.WriteLine($"{Make} {Model} is starting.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for car attributes
            Console.Write("Enter the car make: ");
            string make = Console.ReadLine();

            Console.Write("Enter the car model: ");
            string model = Console.ReadLine();

            Console.Write("Enter the car year: ");
            int year = int.Parse(Console.ReadLine());

            // Create an instance of Car with user input
            Car myCar = new Car(make, model, year);

            // Display car information
            myCar.DisplayInfo();

            // Start the car
            myCar.Start();

            Console.ReadLine(); // Wait for user input before closing
        }
    }
}
