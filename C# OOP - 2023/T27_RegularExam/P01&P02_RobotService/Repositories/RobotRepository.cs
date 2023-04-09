using System;
using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models;

        public RobotRepository()
        {
            models = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models() => models.AsReadOnly();

        public void AddNew(IRobot model)
        {
            models.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            IRobot model = models.FirstOrDefault(m => m.GetType().Name == typeName);

            if (model == null)
            {
                return false;
            }

            return true;
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(m => m.InterfaceStandards.Contains(interfaceStandard));
        }
    }
}