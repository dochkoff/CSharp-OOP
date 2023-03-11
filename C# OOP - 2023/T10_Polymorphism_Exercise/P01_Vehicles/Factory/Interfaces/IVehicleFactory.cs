using System;
using P01_Vehicles.Models.Interfaces;

namespace P01_Vehicles.Factory.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuelQuantity, double fuelConsumption);
    }
}

