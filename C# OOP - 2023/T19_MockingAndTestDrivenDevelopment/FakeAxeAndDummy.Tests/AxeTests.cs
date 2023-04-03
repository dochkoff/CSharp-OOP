using System;
using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

namespace FakeAxeAndDummy.Tests
{
    [TestFixture]
    public class AxeTests
    {
        Axe weapon;
        Dummy target;

        [SetUp]
        public void SetUp()
        {
            weapon = new Axe(10, 10);
            target = new Dummy(10, 10);
        }

        [TearDown]
        public void TearDown()
        {
            weapon = null;
            target = null;
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            int expectedDurability = 9;

            weapon.Attack(target);

            Assert.That(weapon.DurabilityPoints, Is.EqualTo(expectedDurability), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttackingWithABrokenWeapon()
        {
            weapon = new Axe(10, 0);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => weapon.Attack(target), "Broken weapon can attack.");
            Assert.That(exception.Message, Is.EqualTo("Axe is broken."));
        }
    }
}