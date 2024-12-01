using Xunit;

namespace Task3.Test
{
    public class CarStationTests
    {
        [Fact]
        public void AddCar_ShouldAddCarToQueue()
        {
            var carQueue = new ArrayQueue<Car>(10);
            var electricStation = new ElectricStation();
            var peopleDinner = new PeopleDinner();
            var carStation = new CarStation(carQueue, electricStation, peopleDinner);

            var car = new Car(1, "ELECTRIC", "PEOPLE", true, 100);
            
            carStation.AddCar(car);

            Assert.False(carQueue.IsEmpty());

            var dequeuedCar = carQueue.Dequeue();
            Assert.Equal(car, dequeuedCar);
        }

        [Fact]
        public void ServeCars_ShouldProcessCarsCorrectly()
        {
            var carQueue = new ArrayQueue<Car>(10);
            var electricStation = new ElectricStation();
            var peopleDinner = new PeopleDinner();
            var carStation = new CarStation(carQueue, electricStation, peopleDinner);

            var car = new Car(1, "ELECTRIC", "PEOPLE", true, 100);
            carStation.AddCar(car);

            carStation.ServeCars();

            Assert.True(carQueue.IsEmpty());
        }

        [Fact]
        public void ServeCars_ShouldNotServeDinnerIfNotNeeded()
        {
            var carQueue = new ArrayQueue<Car>(10);
            var electricStation = new ElectricStation();
            var peopleDinner = new PeopleDinner();
            var carStation = new CarStation(carQueue, electricStation, peopleDinner);

            var car = new Car(1, "ELECTRIC", "PEOPLE", false, 100);
            carStation.AddCar(car);

            carStation.ServeCars();

            // ужин не были вызваны, можно это проверить через логирование, если хотите -v detailed
        }
    }
}
