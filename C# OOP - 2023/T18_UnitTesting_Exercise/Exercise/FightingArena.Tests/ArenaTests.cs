namespace FightingArena.Tests
{
    using System;
    using System.Linq;
    using System.Threading;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        Arena arena;
        Warrior warrior1;
        Warrior warrior2;
        Warrior warrior3;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior1 = new Warrior("Richi", 10, 50);
            warrior2 = new Warrior("Kuchi", 15, 40);
            warrior3 = new Warrior("Richi", 20, 30);
        }

        [TearDown]
        public void TearDown()
        {
            arena = null;
            warrior1 = null;
            warrior2 = null;
            warrior3 = null;
        }

        [Test]
        public void EnrollWarrior()
        {
            arena.Enroll(warrior1);

            Assert.That(arena.Warriors.Any(w => w.Name == warrior1.Name));
        }

        [Test]
        public void EnrollWarriorWithSameName()
        {
            arena.Enroll(warrior1);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior3));
            Assert.That(exception.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void CountOfEnroledWarriors()
        {
            arena.Enroll(warrior1);
            Assert.That(arena.Count, Is.EqualTo(1));
            Assert.That(arena.Count, Is.EqualTo(arena.Warriors.Count));
        }

        [Test]
        public void FightMethod()
        {
            string attackerName = "Richi";
            string defenderName = "Kuchi";
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Fight(attackerName, defenderName);

            Assert.That(warrior1.HP, Is.EqualTo(35));
            Assert.That(warrior2.HP, Is.EqualTo(30));
        }

        [Test]
        public void FightWithNoSuchAttakerName()
        {
            string attackerName = "Richard";
            string defenderName = "Kuchi";
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
            Assert.That(exception.Message, Is.EqualTo($"There is no fighter with name {attackerName} enrolled for the fights!"));
        }

        [Test]
        public void FightWithNoSuchDefenderName()
        {
            string attackerName = "Richi";
            string defenderName = "Kuchard";
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
            Assert.That(exception.Message, Is.EqualTo($"There is no fighter with name {defenderName} enrolled for the fights!"));
        }
    }
}