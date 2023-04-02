using System;
using P02_Composite.Models.Interfaces;

namespace P02_Composite.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> _gifts;

        public CompositeGift(string name, decimal price)
            : base(name, price)
        {
            _gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift) => _gifts.Add(gift);

        public void Remove(GiftBase gift) => _gifts.Remove(gift);

        public override decimal CalculateTotalPrice()
        {
            decimal total = 0m;

            Console.WriteLine($"{Name} contains the following products with prices:");

            foreach (var gift in _gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}