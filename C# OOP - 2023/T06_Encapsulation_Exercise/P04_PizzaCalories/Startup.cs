using P04_PizzaCalories.Models;

try
{
    string[] pizzaParams = Console.ReadLine().Split();
    string pizzaName = pizzaParams[1];

    string[] doughParams = Console.ReadLine().Split();
    Dough dough = new(doughParams[1], doughParams[2], double.Parse(doughParams[3]));

    Pizza pizza = new(pizzaName, dough);

    string input;
    while ((input = Console.ReadLine()) != "END")
    {
        string[] toppingParams = input.Split();
        Topping topping = new(toppingParams[1], double.Parse(toppingParams[2]));

        pizza.AddTopping(topping);
    }

    Console.WriteLine(pizza);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}