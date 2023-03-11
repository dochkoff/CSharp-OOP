using System;
using P01_Vehicles.Factory.Interfaces;
using P01_Vehicles.Models;
using P01_Vehicles.Models.Interfaces;

namespace P01_Vehicles.Factory
{
    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {
        }

        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}

