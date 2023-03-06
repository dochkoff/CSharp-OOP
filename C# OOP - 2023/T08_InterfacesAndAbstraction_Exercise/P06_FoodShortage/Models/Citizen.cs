using P06_FoodShortage.Models.Interfaces;

namespace P06_FoodShortage.Models
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private const int DefaultFoodIncrement = 10;

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += DefaultFoodIncrement;
        }
    }
}

