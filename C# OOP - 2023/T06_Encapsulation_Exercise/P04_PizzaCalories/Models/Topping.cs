using System;
using System.Collections.ObjectModel;

namespace P04_PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCalories = 2;

        private readonly Dictionary<string, double> types;
        private string type;
        private double weigh;

        public Topping(string type, double weigh)
        {
            types = new Dictionary<string, double>
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };
            Type = type;
            Weigh = weigh;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (!types.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        public double Weigh
        {
            get => weigh;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weigh = value;
            }
        }
        public double Calories
        {
            get => BaseCalories * Weigh * types[Type.ToLower()];
        }
    }
}

