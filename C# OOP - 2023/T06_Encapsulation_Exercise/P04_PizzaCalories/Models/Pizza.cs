using System;
namespace P04_PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Count() < 1 || value.Count() > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough { get; private set; }

        public double TotalCalories { get => Dough.Calories + toppings.Sum(t => t.Calories); }

        public int NumOfToppings
        {
            get => toppings.Count();
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count < 0 || toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:F2} Calories.";
        }
    }
}

