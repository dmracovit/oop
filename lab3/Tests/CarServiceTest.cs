using System;
using Xunit;

namespace Task2.Test
{
    public class CarServiceStationTests
    {
        
        

        [Fact]
        public void TestQueueEmptyAfterProcessing()
        {
            // Arrange
            var carQueue = new ArrayQueue<Car>(5);
            carQueue.Enqueue(new Car(1, "ELECTRIC", "PEOPLE", false, 15));
            carQueue.Enqueue(new Car(2, "GAS", "ROBOTS", true, 20));

            var refuelService = new MockRefuelService();
            var dineService = new MockDineService();
            var serviceStation = new CarServiceStation(carQueue, refuelService, dineService);

            // Act
            serviceStation.ProcessCars();

            // Assert
            Assert.True(carQueue.IsEmpty(), "Queue should be empty after processing all cars.");
        }

        [Fact]
        public void TestNoServiceForCarWithoutDiningOrRefueling()
        {
            // Arrange
            var carQueue = new ArrayQueue<Car>(5);
            var car = new Car(3, "ELECTRIC", "PEOPLE", false, 0); // No consumption means no refueling needed
            carQueue.Enqueue(car);

            var refuelService = new MockRefuelService();
            var dineService = new MockDineService();
            var serviceStation = new CarServiceStation(carQueue, refuelService, dineService);

            // Act
            serviceStation.ProcessCars();

            // Assert
            Assert.False(refuelService.RefuelCalled, "Refuel service should not have been called.");
            Assert.False(dineService.DineCalled, "Dine service should not have been called.");
        }
    }

    // Mock implementations for testing
    public class MockRefuelService : IRefuelable
    {
        public bool RefuelCalled { get; private set; }

        public void Refuel(int carId)
        {
            RefuelCalled = true;
            Console.WriteLine($"MockRefuelService: Refueled car {carId}.");
        }
    }

    public class MockDineService : IDineable
    {
        public bool DineCalled { get; private set; }

        public void ServeDinner(int carId)
        {
            DineCalled = true;
            Console.WriteLine($"MockDineService: Served dinner for car {carId}.");
        }
    }
}
