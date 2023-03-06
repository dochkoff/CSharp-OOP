using System;
namespace P06_FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        public string Name { get; }

        public int Food { get; }

        public void BuyFood();
    }
}