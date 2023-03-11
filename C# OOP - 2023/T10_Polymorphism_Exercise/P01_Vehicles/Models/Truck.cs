using System;
namespace P01_Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
            : base(fuelQuantity, fuelConsumptionPerKm, AirConditionerConsumption)
        {
        }

        public override void Refuel(double fuel) => base.Refuel(fuel * 0.95);
    }
}

