using System;
using P02_VehiclesExtension.Factory.Interfaces;
using P02_VehiclesExtension.Models;
using P02_VehiclesExtension.Models.Interfaces;

namespace P02_VehiclesExtension.Factory
{
    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {
        }

        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}

