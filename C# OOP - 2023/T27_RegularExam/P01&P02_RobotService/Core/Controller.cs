using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            IRobot robot = null;
            if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == "IndustrialAssistant")
            {
                robot = new IndustrialAssistant(model);
            }
            else
            {
                return String.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            robots.AddNew(robot);
            return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);

        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement = null;
            if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == "LaserRadar")
            {
                supplement = new LaserRadar();
            }
            else
            {
                return String.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            supplements.AddNew(supplement);
            return String.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);

            int interfaceValue = supplement.InterfaceStandard;

            List<IRobot> rejectedRobots = robots
                .Models()
                .Where(r => r.InterfaceStandards.Contains(interfaceValue))
                .ToList();

            List<IRobot> searchedRobots = robots
                 .Models()
                 .Except(rejectedRobots)
                 .Where(r => r.Model == model)
                 .ToList();

            if (searchedRobots.Count == 0)
            {
                return String.Format(OutputMessages.AllModelsUpgraded, model);
            }

            searchedRobots
                .First()
                .InstallSupplement(supplement);

            supplements
                .RemoveByName(supplementTypeName);

            return String
                .Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> searchedRobots = robots
                .Models()
                .Where(m => m.InterfaceStandards.Contains(intefaceStandard))
                .ToList();

            if (searchedRobots.Count == 0)
            {
                return String.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            List<IRobot> sortedRobots = searchedRobots
                .OrderByDescending(m => m.BatteryLevel)
                .ToList();

            int availablePower = sortedRobots
                .Sum(m => m.BatteryLevel);

            if (availablePower < totalPowerNeeded)
            {
                int neededPower = totalPowerNeeded - availablePower;

                return String.Format(OutputMessages.MorePowerNeeded, serviceName, neededPower);
            }
            else
            {
                int counter = 0;

                foreach (var robot in sortedRobots)
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);
                        counter++;
                        break;
                    }
                    else
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        counter++;
                    }
                }

                return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
            }
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> searchedRobots = robots
                .Models()
                .Where(m => m.Model == model)
                .Where(m => m.BatteryLevel < m.BatteryCapacity / 2)
                .ToList();

            int counter = 0;
            foreach (var robot in searchedRobots)
            {
                robot.Eating(minutes);
                counter++;
            }

            return String.Format(OutputMessages.RobotsFed, counter);
        }

        public string Report()
        {
            List<IRobot> searchedRobots = robots
                .Models()
                .OrderByDescending(m => m.BatteryLevel)
                .ThenBy(m => m.BatteryCapacity)
                .ToList();

            StringBuilder sb = new();
            foreach (var robot in searchedRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb
                .ToString()
                .Trim();
        }
    }
}

