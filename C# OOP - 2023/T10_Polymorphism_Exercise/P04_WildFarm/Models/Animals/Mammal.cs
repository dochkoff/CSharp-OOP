using P04_WildFarm.Models.Interfaces;

namespace P04_WildFarm.Models.Animals;

public abstract class Mammal : Animal, IMammal
{
    protected Mammal(string name, double weight, string livingRegion)
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public string LivingRegion { get; private set; }
}
