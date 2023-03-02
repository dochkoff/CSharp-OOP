using System.Linq;
using P03_ShoppingSpree.Models;

List<Person> people = new();
List<Product> products = new();

try
{
    string[] peopleInput = Console.ReadLine()
    .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < peopleInput.Length; i += 2)
    {
        Person person = new(peopleInput[i], decimal.Parse(peopleInput[i + 1]));
        people.Add(person);
    }

    string[] productsInput = Console.ReadLine()
        .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < productsInput.Length; i += 2)
    {
        Product product = new(productsInput[i], decimal.Parse(productsInput[i + 1]));
        products.Add(product);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] inputElements = input.Split();
    string personName = inputElements[0];
    string productName = inputElements[1];

    foreach (var person in people)
    {
        if (person.Name == personName)
        {
            foreach (var product in products)
            {
                if (product.Name == productName)
                {
                    if (person.Modey >= product.Cost)
                    {
                        person.Modey -= product.Cost;
                        person.Bag.Add(product);

                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                }
            }
        }
    }
}

foreach (var person in people)
{
    string productString = person.Bag.Any()
        ? string.Join(", ", person.Bag)
        : "Nothing bought";

    Console.WriteLine($"{person.Name} - {productString}");

}