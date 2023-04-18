using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        private List<Vehicle> vehicles;

        public VehicleRepository()
        {
            vehicles = new();
        }

        public void AddModel(Vehicle model)
        {
            vehicles.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            Vehicle vehicle = vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);

            if (vehicle == null)
            {
                return false;
            }
            else
            {
                vehicles.Remove(vehicle);
                return true;
            }
        }

        public Vehicle FindById(string identifier)
        {
            return vehicles.FirstOrDefault(u => u.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<Vehicle> GetAll()
        {
            return vehicles.AsReadOnly();
        }
    }
}

