using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private List<User> users;

        public UserRepository()
        {
            users = new();
        }

        public void AddModel(User model)
        {
            users.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            User user = users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

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

        public User FindById(string identifier)
        {
            return users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return users.AsReadOnly();
        }
    }
}

