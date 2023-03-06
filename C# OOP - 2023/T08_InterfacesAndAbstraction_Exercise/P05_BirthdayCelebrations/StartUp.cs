using P05_BirthdayCelebrations.Models;

List<IBirthable> celebrators = new();

string input;
while ((input = Console.ReadLine()) != "End")
{
    string[] tokens = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (tokens[0] == "Citizen")
    {
        IBirthable citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
        celebrators.Add(citizen);
    }
    else if (tokens[0] == "Pet")
    {
        IBirthable pet = new Pet(tokens[1], tokens[2]);
        celebrators.Add(pet);
    }
}

string year = Console.ReadLine();

foreach (var individ in celebrators)
{
    if (individ.Birthdate.EndsWith(year))
    {
        Console.WriteLine(individ.Birthdate);
    }
}