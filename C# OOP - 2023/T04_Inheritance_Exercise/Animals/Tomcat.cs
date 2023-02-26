using System;
namespace Animals
{
    public class Tomcat : Cat
    {
        private const string gender = "male";

        public Tomcat(string name, int age) :
            base(name, age, gender)
        {
        }

        public override string ProduceSound() => "MEOW";
    }
}