using System;
namespace P02_VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumptionPerKm { get; }
        public double TankCapacity { get; }


        public string Drive(double distance, bool isIncreasedConsumption);
        public void Refuel(double fuel);
    }
}

