using System;
namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        private const int cargoVanMaxMiliage = 180;

        public CargoVan(string brand, string model, string licensePlateNumber)
            : base(brand, model, cargoVanMaxMiliage, licensePlateNumber)
        {
        }
    }
}