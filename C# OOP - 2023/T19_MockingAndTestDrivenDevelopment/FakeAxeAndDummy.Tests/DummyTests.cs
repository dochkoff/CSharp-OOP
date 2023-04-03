using System;
using FakeAxeAndDummy;
using NUnit.Framework;

namespace FakeAxeAndDummy.Tests
{
    [TestFixture]
    public class DummyTests
    {
        Dummy target;

        [SetUp]
        public void SetUp()
        {
            target = new Dummy(10, 10);
        }

        [TearDown]
        public void TearDown()
        {
            target = null;
        }

        [Test]
        public void DummnyLosesHealthIfAttacked()
        {
            int desiredHealthPoints = 5;
            target.TakeAttack(5);

            Assert.That(target.Health, Is.EqualTo(desiredHealthPoints), "Dummy doesn't lose health if attacked.");
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            target = new Dummy(0, 10);
            int attackPoints = 5;

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => target.TakeAttack(attackPoints), "Dead Dummy doesn't throw an exception if attacked.");
            Assert.That(exception.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            target = new Dummy(0, 10);
            int desiredExperience = 10;
            int givedExperience = target.GiveExperience();

            Assert.That(givedExperience, Is.EqualTo(desiredExperience), "Dead Dummy can't give XP.");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => target.GiveExperience(), "Alive Dummy can give XP.");
            Assert.That(exception.Message, Is.EqualTo("Target is not dead."));
        }
    }
}