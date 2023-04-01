using System;
using P03_CommandPattern.Enum;
using P03_CommandPattern.Interfaces;

namespace P03_CommandPattern.Commands
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly int _amaunt;

        public ProductCommand(Product product, PriceAction priceAction, int amaunt)
        {
            _product = product;
            _priceAction = priceAction;
            _amaunt = amaunt;
        }

        public void ExecuteAction()
        {
            if (_priceAction == PriceAction.Increase)
            {
                _product.IncreasePrice(_amaunt);
            }
            else
            {
                _product.DecreasePrice(_amaunt);
            }
        }
    }
}