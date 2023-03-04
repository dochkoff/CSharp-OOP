using System;
namespace Cars.Models
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }


        public string Model { get => model; private set => model = value; }
        public string Color { get => color; private set => color = value; }
        public int Battery { get => battery; private set => battery = value; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {battery} Batteries";
        }
    }
}

