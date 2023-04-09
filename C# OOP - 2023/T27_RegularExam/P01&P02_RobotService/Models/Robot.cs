using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int conversionCapacityIndex;
        private List<int> interfaceStandards;

        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            this.model = model;
            this.batteryCapacity = batteryCapacity;
            this.batteryLevel = batteryCapacity;
            this.conversionCapacityIndex = conversionCapacityIndex;
            interfaceStandards = new List<int>();
        }


        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(model))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }

                model = value;
            }
        }



        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if (batteryCapacity < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set
            {
                batteryLevel = value;
            }
        }

        public int ConvertionCapacityIndex
        {
            get { return conversionCapacityIndex; }
            private set
            {
                conversionCapacityIndex = value;
            }
        }
        //FIXME Private set?
        public IReadOnlyCollection<int> InterfaceStandards
        {
            get { return interfaceStandards.AsReadOnly(); }
            private set
            {
                InterfaceStandards = value;
            }
        }



        public void Eating(int minutes)
        {
            int producedEnergy = minutes * this.conversionCapacityIndex;
            batteryLevel += producedEnergy;

            if (batteryLevel > batteryCapacity)
            {
                batteryLevel = batteryCapacity;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            batteryLevel -= supplement.BatteryUsage;
            batteryCapacity -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (batteryLevel >= consumedEnergy)
            {
                batteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            string standarts = string.Empty;

            if (interfaceStandards.Count == 0)
            {
                standarts = "none";
            }
            else
            {
                standarts = string.Join(" ", interfaceStandards);
            }

            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.AppendLine($"--Supplements installed: {standarts}");

            return sb
                .ToString()
                .Trim();
        }
    }
}