using System;
using P02_VehiclesExtension.Models.Interfaces;

namespace P02_VehiclesExtension.Factory.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}

