using System;
namespace P02_VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity, AirConditionerConsumption)
        {
        }
    }
}

