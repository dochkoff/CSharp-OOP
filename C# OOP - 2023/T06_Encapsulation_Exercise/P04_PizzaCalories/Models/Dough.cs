using System;
namespace P04_PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCalories = 2;

        private string flourType;
        private string bakingTechnique;
        private double modifierType;
        private double modifierTechnique;
        private double weigh;

        public Dough(string flourType, string bakingTechnique, double weigh)
        {
            FlourType = flourType.ToLower();
            BakingTechnique = bakingTechnique.ToLower();
            Weigh = weigh;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                flourType = value.ToLower();
                switch (this.flourType)
                {
                    case "white":
                        modifierType = 1.5;
                        break;
                    case "wholegrain":
                        modifierType = 1.0;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                        break;
                }
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                bakingTechnique = value.ToLower();
                switch (bakingTechnique)
                {
                    case "crispy":
                        modifierTechnique = 0.9;
                        break;
                    case "chewy":
                        modifierTechnique = 1.1;
                        break;
                    case "homemade":
                        modifierTechnique = 1.0;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                        break;
                }
            }
        }

        public double Weigh
        {
            get => weigh;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weigh = value;
            }
        }

        public double Calories
        {
            get => BaseCalories * Weigh * modifierType * modifierTechnique;
        }
    }
}

