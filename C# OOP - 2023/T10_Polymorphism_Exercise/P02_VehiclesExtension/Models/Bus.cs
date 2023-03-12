using System;
namespace P02_VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity, AirConditionerConsumption)
        {
        }
    }
}

