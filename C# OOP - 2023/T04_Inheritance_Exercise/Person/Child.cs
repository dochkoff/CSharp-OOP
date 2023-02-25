using System;
namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (Age <= 15)
                {
                    base.Age = value;
                }
            }
        }
    }
}