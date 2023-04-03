using System;
using FakeAxeAndDummy;

public class Dummy : ITarget
{
    private int health;
    private int experience;

    public Dummy(int health, int experience)
    {
        this.Health = health;
        this.Experience = experience;
    }

    public int Health
    {
        get => this.health;

        set
        {
            health = value;
        }
    }

    public int Experience
    {
        get => this.experience;

        set
        {
            if (this.experience < 0)
            {
                throw new ArgumentException("Experience cannot be a negative number");
            }

            experience = value;
        }
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.health -= attackPoints;

        if (this.health < 0)
        {
            this.health = 0;
        }
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.experience;
    }

    public bool IsDead()
    {
        return this.health == 0;
    }
}
