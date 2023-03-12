using System;
namespace P02_VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity, AirConditionerConsumption)
        {
        }

        public override void Refuel(double fuel)
        {
            if (fuel + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            base.Refuel(fuel * 0.95);
        }
    }
}

