using System;
using System.Collections.Generic;
using P04_WildFarm.Models.Foods;

namespace P04_WildFarm.Models.Animals;

public class Owl : Bird
{
    private const double OwlWeightMultiplier = 0.25;

    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    { }

    public override IReadOnlyCollection<Type> PreferredFoods
        => new HashSet<Type>() { typeof(Meat) };

    protected override double WeightMultiplier
        => OwlWeightMultiplier;

    public override string ProduceSound()
        => "Hoot Hoot";
}
