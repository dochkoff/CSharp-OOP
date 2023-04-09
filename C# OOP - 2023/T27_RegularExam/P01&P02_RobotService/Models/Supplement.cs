using System;
using RobotService.Models.Contracts;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        private int interfaceStandard;
        private int batteryUsage;

        public Supplement(int interfaceStandard, int batteryUsage)
        {
            this.interfaceStandard = interfaceStandard;
            this.batteryUsage = batteryUsage;
        }

        public int InterfaceStandard
        {
            get => interfaceStandard;
            private set => interfaceStandard = value;
        }

        public int BatteryUsage
        {
            get => batteryUsage;
            private set => batteryUsage = value;
        }
    }
}