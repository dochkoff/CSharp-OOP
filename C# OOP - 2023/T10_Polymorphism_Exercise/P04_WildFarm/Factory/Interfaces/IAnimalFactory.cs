using P04_WildFarm.Models.Interfaces;

namespace P04_WildFarm.Factories.Interfaces;

public interface IAnimalFactory
{
    IAnimal CreateAnimal(string[] animalTokens);
}
