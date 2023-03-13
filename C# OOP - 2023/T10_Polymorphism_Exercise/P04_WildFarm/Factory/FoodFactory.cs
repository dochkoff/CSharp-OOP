﻿using System;
using P04_WildFarm.Factories.Interfaces;
using P04_WildFarm.Models.Foods;
using P04_WildFarm.Models.Interfaces;

namespace P04_WildFarm.Factories;

public class FoodFactory : IFoodFactory
{
    public IFood CreateFood(string type, int quantity)
    {
        switch (type)
        {
            case "Vegetable":
                return new Vegetable(quantity);
            case "Fruit":
                return new Fruit(quantity);
            case "Meat":
                return new Meat(quantity);
            case "Seeds":
                return new Seeds(quantity);
            default:
                throw new ArgumentException("Invalid food type!");
        }
    }
}