﻿using System;
namespace EDriveRent.Models
{
    public class PassengerCar : Vehicle
    {
        private const int passengerCarMaxMiliage = 450;

        public PassengerCar(string brand, string model, string licensePlateNumber)
            : base(brand, model, passengerCarMaxMiliage, licensePlateNumber)
        {
        }
    }
}

