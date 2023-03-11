using System;
using P01_Vehicles.Models.Interfaces;

namespace P01_Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double airConditionerConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double airConditionerConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.airConditionerConsumption = airConditionerConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKm { get; private set; }


        public string Drive(double distance)
        {
            double totalConsumption = FuelConsumptionPerKm + airConditionerConsumption;

            if (distance * totalConsumption > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * totalConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel) => FuelQuantity += fuel;

        public override string ToString() => $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}

