namespace P09_ExplicitInterfaces.Models.Interfaces;

public interface IResident
{
    string Name { get; }

    string Country { get; }

    string GetName();
}
