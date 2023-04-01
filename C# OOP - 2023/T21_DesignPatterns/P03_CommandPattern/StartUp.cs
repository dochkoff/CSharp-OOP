
using P03_CommandPattern;
using P03_CommandPattern.Commands;
using P03_CommandPattern.Enum;
using P03_CommandPattern.Interfaces;

ModifyPrice modifyPrice = new();
Product product = new("iPhone", 500);

Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

Console.WriteLine(product);

void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
{
    modifyPrice.SetCommand(productCommand);
    modifyPrice.Invoke();
}