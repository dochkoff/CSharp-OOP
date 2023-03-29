namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Toyota", "Avensis", 7, 60);
        }

        [TearDown]
        public void TearDown()
        {
            car = null;
        }

        [Test]
        public void CreateNewCar()
        {
            Assert.That(car.Model, Is.EqualTo("Avensis"));
            Assert.That(car.FuelConsumption, Is.EqualTo(7));
            Assert.That(car.FuelCapacity, Is.EqualTo(60));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void SetNullOrEmptyCarMake()
        {
            ArgumentException exception1 =
                Assert.Throws<ArgumentException>(() => car = new Car(null, "c", 7, 60));
            Assert.That(exception1.Message, Is.EqualTo("Make cannot be null or empty!"));

            ArgumentException exception2 =
                Assert.Throws<ArgumentException>(() => car = new Car(string.Empty, "Avensis", 7, 60));
            Assert.That(exception2.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void SetNullOrEmptyCarModel()
        {
            ArgumentException exception1 =
                Assert.Throws<ArgumentException>(() => car = new Car("Toyota", null, 7, 60));
            Assert.That(exception1.Message, Is.EqualTo("Model cannot be null or empty!"));

            ArgumentException exception2 =
                Assert.Throws<ArgumentException>(() => car = new Car("Toyota", string.Empty, 7, 60));
            Assert.That(exception2.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void SetFuelConsumptionZeroOrNegative()
        {
            ArgumentException exception1 =
                Assert.Throws<ArgumentException>(() => car = new Car("Toyota", "Avensis", 0, 60));
            Assert.That(exception1.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));

            ArgumentException exception2 =
                Assert.Throws<ArgumentException>(() => car = new Car("Toyota", "Avensis", -1, 60));
            Assert.That(exception2.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void SetFuelCapacityZeroOrNegative()
        {
            ArgumentException exception1 =
                Assert.Throws<ArgumentException>(() => car = new Car("Toyota", "Avensis", 7, 0));
            Assert.That(exception1.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));

            ArgumentException exception2 =
                Assert.Throws<ArgumentException>(() => car = new Car("Toyota", "Avensis", 7, -1));
            Assert.That(exception2.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void RefuelMethod()
        {
            double fuelToRefuel = 10;
            car.Refuel(fuelToRefuel);

            Assert.That(car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void RefuelMethodIfFuelAmountIsBiggerThanFuelCapacity()
        {
            double fuelToRefuel = 61;
            car.Refuel(fuelToRefuel);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void RefuelWithZeroOrNegative()
        {
            double fuelToRefuel = -1;

            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
            Assert.That(exception.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void DriveMethod()
        {
            double fuelToRefuel = 60;
            car.Refuel(fuelToRefuel);
            double distance = 100;
            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(53));
        }

        [Test]
        public void DriveMethodWithLongDistance()
        {
            double fuelToRefuel = 60;
            car.Refuel(fuelToRefuel);
            double distance = 860;

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
            Assert.That(exception.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }
    }


}