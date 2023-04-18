using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<Route>
    {
        private List<Route> routes;

        public RouteRepository()
        {
            routes = new();
        }

        public void AddModel(Route model)
        {
            routes.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            Route route = routes.FirstOrDefault(u => u.RouteId == int.Parse(identifier));

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

        public Route FindById(string identifier)
        {
            return routes.FirstOrDefault(u => u.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<Route> GetAll()
        {
            return routes.AsReadOnly();
        }
    }
}

