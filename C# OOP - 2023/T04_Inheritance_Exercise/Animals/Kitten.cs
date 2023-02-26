﻿using System;
namespace Animals
{
    public class Kitten : Cat
    {
        private const string gender = "female";

        public Kitten(string name, int age)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound() => "Meow";
    }
}

