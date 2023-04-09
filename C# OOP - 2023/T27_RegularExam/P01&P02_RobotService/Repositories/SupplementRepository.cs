using System;
using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> models;

        public SupplementRepository()
        {
            models = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models() => models.AsReadOnly();

        public void AddNew(ISupplement model)
        {
            models.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            ISupplement model = models.FirstOrDefault(m => m.GetType().Name == typeName);

            if (model == null)
            {
                return false;
            }

            return true;
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(m => m.InterfaceStandard == interfaceStandard);
        }
    }
}

