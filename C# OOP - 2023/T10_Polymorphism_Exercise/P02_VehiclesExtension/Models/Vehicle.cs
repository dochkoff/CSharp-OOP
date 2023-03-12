using System;
using P02_VehiclesExtension.Models.Interfaces;

namespace P02_VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double airConditionerConsumption;
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity, double airConditionerConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.airConditionerConsumption = airConditionerConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (TankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumptionPerKm { get; private set; }

        public double TankCapacity { get; private set; }


        public string Drive(double distance, bool isIncreasedConsumption = true)
        {
            double totalConsumption = isIncreasedConsumption
                ? FuelConsumptionPerKm + airConditionerConsumption
                : FuelConsumptionPerKm;

            if (distance * totalConsumption > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * totalConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }
            FuelQuantity += fuel;
        }

        public override string ToString() => $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}