using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;

        public VehicleRepository()
        {
            vehicles = new();
        }

        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            IVehicle vehicle = vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);

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

        public IVehicle FindById(string identifier)
        {
            return vehicles.FirstOrDefault(u => u.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return vehicles.AsReadOnly();
        }
    }
}

