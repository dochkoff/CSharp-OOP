﻿using System;
using P01_Vehicles.Models.Interfaces;

namespace P01_Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm)
            : base(fuelQuantity, fuelConsumptionPerKm, AirConditionerConsumption)
        {
        }
    }
}

