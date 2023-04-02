﻿using System;
namespace P02_Composite.Models
{
    public abstract class GiftBase
    {
        public GiftBase(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public abstract decimal CalculateTotalPrice();
    }
}