using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy target = new(10, 10);


            axe.Attack(target);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttackingWithABrokenWeapon()
        {
            Axe axe = new Axe(10, 0);
            Dummy target = new(10, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(target));
        }
    }
}