using P04_WildFarm.Models.Interfaces;

namespace P04_WildFarm.Factories.Interfaces;

public interface IFoodFactory
{
    IFood CreateFood(string type, int quantity);
}
