using P06_FoodShortage.Models;
using P06_FoodShortage.Models.Interfaces;

List<IBuyer> buyers = new();

int numOfBuyers = int.Parse(Console.ReadLine());

for (int i = 0; i < numOfBuyers; i++)
{
    string[] tokens = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (tokens.Count() == 4)
    {
        IBuyer citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
        buyers.Add(citizen);
    }
    else
    {
        IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
        buyers.Add(rebel);
    }
}

string name;
while ((name = Console.ReadLine()) != "End")
{
    buyers.FirstOrDefault(buyer => buyer.Name == name)?.BuyFood();
}

Console.WriteLine(buyers.Sum(x => x.Food));