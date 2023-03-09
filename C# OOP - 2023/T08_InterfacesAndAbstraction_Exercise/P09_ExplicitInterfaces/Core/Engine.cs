using P09_ExplicitInterfaces.Core.Interfaces;
using P09_ExplicitInterfaces.Models;
using P09_ExplicitInterfaces.Models.Interfaces;

namespace P09_ExplicitInterfaces.Core;

public class Engine : IEngine
{
    public void Run()
    {
        List<Citizen> citizens = new();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "End")
            {
                break;
            }

            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            citizens.Add(new Citizen(tokens[0], tokens[1], int.Parse(tokens[2])));
        }

        foreach (var citizen in citizens)
        {
            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}