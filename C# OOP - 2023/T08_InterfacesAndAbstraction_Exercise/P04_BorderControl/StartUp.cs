using P04_BorderControl.Models;

List<IIdentifiable> control = new();

string input;
while ((input = Console.ReadLine()) != "End")
{
    string[] tokens = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (tokens.Length == 2)
    {
        IIdentifiable robot = new Robot(tokens[0], tokens[1]);
        control.Add(robot);
    }
    else
    {
        IIdentifiable citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
        control.Add(citizen);
    }
}

string fakeId = Console.ReadLine();

foreach (var individ in control)
{
    if (individ.ID.EndsWith(fakeId))
    {
        Console.WriteLine(individ.ID);
    }
}