namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        Warrior warrior;
        private const int MinAttackHP = 30;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Richi", 10, 50);

        }

        [TearDown]
        public void TearDown()
        {
            warrior = null;
        }

        [Test]
        public void CreateWarrior()
        {
            Assert.That(warrior.Name, Is.EqualTo("Richi"));
            Assert.That(warrior.Damage, Is.EqualTo(10));
            Assert.That(warrior.HP, Is.EqualTo(50));
        }

        [Test]
        public void SetNullOrEmptyWarriorName()
        {
            ArgumentException exception1 =
                Assert.Throws<ArgumentException>(() => warrior = new Warrior(null, 10, 50));
            Assert.That(exception1.Message, Is.EqualTo("Name should not be empty or whitespace!"));

            ArgumentException exception2 =
                Assert.Throws<ArgumentException>(() => warrior = new Warrior(string.Empty, 10, 50));
            Assert.That(exception2.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void SetNegativeOrZeroWarriorDamage()
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => warrior = new Warrior("Richi", 0, 50));
            Assert.That(exception.Message, Is.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void SetNegativeWarriorHP()
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => warrior = new Warrior("Richi", 10, -1));
            Assert.That(exception.Message, Is.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackWhenTargetWarriorIsWithBiggerHPThanWarriorDamage()
        {
            Warrior targetWarrior = new("Kuchi", 5, 60);
            warrior.Attack(targetWarrior);

            Assert.That(warrior.HP, Is.EqualTo(45));
            Assert.That(targetWarrior.HP, Is.EqualTo(50));
        }

        [Test]
        public void AttackWhenTargetWarriorIsWithSmallerHPThanWarriorDamage()
        {
            Warrior warrior = new("Richi", 40, 50);
            Warrior targetWarrior = new("Kuchi", 5, 35);
            warrior.Attack(targetWarrior);

            Assert.That(targetWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void AttackWhenHPIsBelowTheMinimum()
        {
            Warrior warrior = new("Richi", 10, 20);
            Warrior targetWarrior = new("Kuchi", 5, 60);


            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => warrior.Attack(targetWarrior));
            Assert.That(exception.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackWhenTargetWariorHPIsBelowTheMinimum()
        {
            Warrior targetWarrior = new("Kuchi", 5, 20);


            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => warrior.Attack(targetWarrior));
            Assert.That(exception.Message, Is.EqualTo($"Enemy HP must be greater than {MinAttackHP} in order to attack him!"));
        }

        [Test]
        public void AttackWhenTryToAttackStrongerEnemy()
        {
            Warrior targetWarrior = new("Kuchi", 60, 60);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => warrior.Attack(targetWarrior));
            Assert.That(exception.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }
    }
}