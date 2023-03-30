using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummnyLosesHealthIfAttacked()
        {
            Dummy target = new(10, 10);

            target.TakeAttack(5);

            Assert.That(target.Health, Is.EqualTo(5), "Dummy doesn't lose health if attacked.");
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            Dummy target = new(4, 10);

            target.TakeAttack(5);

            Assert.Throws<InvalidOperationException>(() => target.TakeAttack(5), "Dead Dummy doesn't throw an exception if attacked.");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy target = new(0, 10);

            int exp = target.GiveExperience();

            Assert.That(exp, Is.EqualTo(10), "Dead Dummy can't give XP.");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy target = new(10, 10);

            Assert.Throws<InvalidOperationException>(() => target.GiveExperience(), "Alive Dummy can give XP.");
        }
    }
}