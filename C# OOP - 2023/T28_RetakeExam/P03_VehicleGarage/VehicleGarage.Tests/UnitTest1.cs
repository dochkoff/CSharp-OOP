using System.Linq;
using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        Vehicle car;
        Garage garage;

        [SetUp]
        public void Setup()
        {
            car = new("Toyota", "Avensis", "CT7153PN", 1000);
            garage = new(10);
        }

        [Test]
        public void VehicleCtor()
        {
            Assert.AreEqual("Toyota", car.Brand);
            Assert.AreEqual("Avensis", car.Model);
            Assert.AreEqual("CT7153PN", car.LicensePlateNumber);
            Assert.AreEqual(100, car.BatteryLevel);
            Assert.AreEqual(false, car.IsDamaged);
        }

        [Test]
        public void GarageCtor()
        {
            Assert.AreEqual(10, garage.Capacity);
            Assert.AreEqual(0, garage.Vehicles.Count);

        }

        [Test]
        public void GarageAddVehicle()
        {
            bool result = garage.AddVehicle(car);

            Assert.AreEqual(true, result);
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.AreEqual(car, garage.Vehicles.First());

        }

        [Test]
        public void GarageAddVehicleButItIsFull()
        {
            Garage garage = new(0);
            bool result = garage.AddVehicle(car);

            Assert.AreEqual(false, result);
            Assert.AreEqual(0, garage.Vehicles.Count);

        }

        [Test]
        public void GarageAddVehicleButCarIsAlreadyThere()
        {
            garage.AddVehicle(car);
            bool result = garage.AddVehicle(car);

            Assert.AreEqual(false, result);
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.AreEqual(car, garage.Vehicles.First());

        }

        [Test]
        public void GarageChargeVehicles()
        {
            garage.AddVehicle(car);
            car.BatteryLevel = 50;
            int chargedVehicles = garage.ChargeVehicles(80);

            Assert.AreEqual(100, car.BatteryLevel);
            Assert.AreEqual(1, chargedVehicles);

            car.BatteryLevel = 90;
            chargedVehicles = garage.ChargeVehicles(80);

            Assert.AreEqual(90, car.BatteryLevel);
            Assert.AreEqual(0, chargedVehicles);
        }

        [Test]
        public void GarageDriveVehicle()
        {
            garage.AddVehicle(car);

            garage.DriveVehicle("CT7153PN", 10, false);
            Assert.AreEqual(90, car.BatteryLevel);

            garage.DriveVehicle("CT7153PN", 120, false);
            Assert.AreEqual(90, car.BatteryLevel);
            Assert.AreEqual(false, car.IsDamaged);

            garage.DriveVehicle("CT7153PN", 10, true);
            Assert.AreEqual(80, car.BatteryLevel);
            Assert.AreEqual(true, car.IsDamaged);

            car.IsDamaged = true;
            garage.DriveVehicle("CT7153PN", 10, true);
            Assert.AreEqual(80, car.BatteryLevel);
            Assert.AreEqual(true, car.IsDamaged);

        }

        [Test]
        public void GarageRepairVehicles()
        {
            garage.AddVehicle(car);
            string repairedVehicles = garage.RepairVehicles();

            Assert.AreEqual("Vehicles repaired: 0", repairedVehicles);

            car.IsDamaged = true;
            repairedVehicles = garage.RepairVehicles();

            Assert.AreEqual("Vehicles repaired: 1", repairedVehicles);
            Assert.AreEqual(false, car.IsDamaged);

        }
    }
}