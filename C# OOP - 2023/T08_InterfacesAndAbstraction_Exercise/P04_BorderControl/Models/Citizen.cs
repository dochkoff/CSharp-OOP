using System;
namespace P04_BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }
    }
}

