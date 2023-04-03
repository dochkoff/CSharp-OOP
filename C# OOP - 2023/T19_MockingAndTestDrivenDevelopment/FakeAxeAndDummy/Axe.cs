using System;
using FakeAxeAndDummy;

public class Axe : IWeapon
{
    private int attackPoints;
    private int durabilityPoints;

    public Axe(int attack, int durability)
    {
        this.attackPoints = attack;
        this.durabilityPoints = durability;
    }

    public int AttackPoints
    {
        get => this.attackPoints;

        set
        {
            if (this.attackPoints <= 0)
            {
                throw new ArgumentException("Attack points must be a positive number");
            }

            attackPoints = value;
        }
    }

    public int DurabilityPoints
    {
        get => this.durabilityPoints;

        set
        {
            if (this.durabilityPoints <= 0)
            {
                throw new ArgumentException("Durability points must be a positive number");
            }

            attackPoints = value;
        }
    }

    public void Attack(ITarget target)
    {
        if (this.durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        this.durabilityPoints -= 1;
    }
}
