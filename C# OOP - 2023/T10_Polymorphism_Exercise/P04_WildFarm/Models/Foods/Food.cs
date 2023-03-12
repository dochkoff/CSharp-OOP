using P04_WildFarm.Models.Interfaces;

namespace P04_WildFarm.Models.Foods;

public abstract class Food : IFood
{
    protected Food(int quantity)
    {
        Quantity = quantity;
    }

    public int Quantity { get; private set; }
}
