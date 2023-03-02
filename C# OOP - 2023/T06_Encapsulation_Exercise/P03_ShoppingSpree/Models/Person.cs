using System;
namespace P03_ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal modey;
        private List<Product> bag;

        public Person(string name, decimal modey)
        {
            Name = name;
            Modey = modey;
            Bag = new();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Modey
        {
            get => modey;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                modey = value;
            }
        }
        public List<Product> Bag
        {
            get => bag;
            set => bag = value;
        }



    }
}

