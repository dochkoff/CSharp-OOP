using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;

        public UserRepository()
        {
            users = new();
        }

        public void AddModel(IUser model)
        {
            users.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            IUser user = users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

            if (user == null)
            {
                return false;
            }
            else
            {
                users.Remove(user);
                return true;
            }
        }

        public IUser FindById(string identifier)
        {
            return users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return users.AsReadOnly();
        }
    }
}

