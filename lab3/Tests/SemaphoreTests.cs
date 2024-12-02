using System;
using Xunit;

namespace Task4.Test
{
    public class SemaphoreTests
    {
        [Fact]
        public void ServeCars_ShouldServeGasCarsWithGasStation()
        {
            var carQueue = new ArrayQueue<Car>(10);
            var gasStation = new GasStation();  
            var peopleDinner = new PeopleDinner();  
            var semaphore = new Semaphore(2); 
            var carStation = new CarStation(carQueue, gasStation, peopleDinner, semaphore, 2);

            var gasCar = new Car(1, "GAS", "PEOPLE", true, 50);
            carStation.AddCar(gasCar);  

            carStation.ServeCars();

            Assert.True(carQueue.IsEmpty());
        }

        [Fact]
        public void ServeCars_ShouldServeElectricCarsWithElectricStation()
        {
            var carQueue = new ArrayQueue<Car>(10);
            var electricStation = new ElectricStation(); 
            var peopleDinner = new PeopleDinner(); 
            var semaphore = new Semaphore(2);  
            var carStation = new CarStation(carQueue, electricStation, peopleDinner, semaphore, 2);

            var electricCar = new Car(2, "ELECTRIC", "PEOPLE", true, 50);
            carStation.AddCar(electricCar);  

            carStation.ServeCars();

            Assert.True(carQueue.IsEmpty());
        }
    }
}
