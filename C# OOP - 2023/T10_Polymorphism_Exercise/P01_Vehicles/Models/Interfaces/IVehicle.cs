using System;
namespace P01_Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumptionPerKm { get; }


        public string Drive(double distance);
        public void Refuel(double fuel);
    }
}

