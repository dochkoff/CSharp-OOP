using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;

        public RouteRepository()
        {
            routes = new();
        }

        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            IRoute route = routes.FirstOrDefault(u => u.RouteId == int.Parse(identifier));

            if (route == null)
            {
                return false;
            }
            else
            {
                routes.Remove(route);
                return true;
            }
        }

        public IRoute FindById(string identifier)
        {
            return routes.FirstOrDefault(u => u.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return routes.AsReadOnly();
        }
    }
}

