using System;
using System.Collections.Generic;
using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

namespace FakeAxeAndDummy.Tests
{
    [TestFixture]
    public class HeroTests
    {
        Mock<IWeapon> fakeWeapon;
        Mock<ITarget> fakeTarget;
        Hero hero;


        [SetUp]
        public void SetUp()
        {
            fakeWeapon = new();
            fakeTarget = new();
            hero = new("Test", (IWeapon)fakeWeapon.Object);

        }

        [TearDown]
        public void TearDown()
        {
            fakeTarget = null;
            fakeWeapon = null;
            hero = null;
        }

        [Test]
        public void GainXPFromDeadTarget()
        {
            fakeTarget
                .Setup(t => t.GiveExperience())
                .Returns(10);
            fakeTarget
              .Setup(p => p.Health)
              .Returns(0);
            fakeTarget
                .Setup(t => t.IsDead())
                .Returns(true);

            hero.Weapon.Attack(fakeTarget.Object);
            int desiredExperience = 10;


            Assert.That(fakeTarget.Object.GiveExperience(), Is.EqualTo(desiredExperience));
            Assert.That(fakeTarget.Object.IsDead(), Is.EqualTo(true));
            Assert.That(fakeTarget.Object.Health, Is.EqualTo(0));
        }
    }
}