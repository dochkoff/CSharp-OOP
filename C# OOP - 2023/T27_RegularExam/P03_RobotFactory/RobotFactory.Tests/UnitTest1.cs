using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;
        [SetUp]
        public void Setup()
        {
            factory = new Factory("Testla", 10);
        }

        [Test]
        public void CtroShouldWork()
        {
            Factory factory = new Factory("Testla", 10);
            Assert.AreEqual("Testla", factory.Name);
            Assert.AreEqual(10, factory.Capacity);
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
        }

        [Test]
        public void ProduceRobotShoulThrow()
        {
            Factory factory = new Factory("Testla", 0);
            //Robot robot = new Robot("X", 10.0, 10);
            //factory.ProduceRobot("X", 10.0, 10);

            Assert.AreEqual("The factory is unable to produce more robots for this production day!", factory.ProduceRobot("X", 10.0, 10));
            Assert.AreEqual(0, factory.Robots.Count);
        }

        [Test]
        public void ProduceRobotShouldWork()
        {
            Factory factory = new Factory("Testla", 10);
            Assert.AreEqual($"Produced --> Robot model: X IS: 10, Price: 10.00", factory.ProduceRobot("X", 10.0, 10));
            Assert.AreEqual(1, factory.Robots.Count);
        }

        [Test]
        public void ProduceSupplShouldWork()
        {

            Assert.AreEqual("Supplement: falconWings IS: 10", factory.ProduceSupplement("falconWings", 10));
            Assert.AreEqual(1, factory.Supplements.Count);
        }

        [Test]
        public void UpgradeShouldReturnFalse()
        {
            Robot robot = new Robot("X", 10.0, 10);
            Supplement supl = new Supplement("falconWings", 9);
            factory.ProduceRobot("X", 10.0, 10);
            factory.ProduceSupplement("falconWings", 10);

            Assert.IsFalse(factory.UpgradeRobot(robot, supl));
        }

        [Test]
        public void UpgradeShouldReturnTrue()
        {
            Robot robot = new Robot("X", 10.0, 10);
            Supplement supl = new Supplement("falconWings", 10);
            factory.ProduceRobot("X", 10.0, 10);
            factory.ProduceSupplement("falconWings", 10);

            Assert.IsTrue(factory.UpgradeRobot(robot, supl));
            Assert.AreEqual(1, robot.Supplements.Count);
        }

        [Test]
        public void SellRobotShouldWork()
        {

            Robot robot1 = new Robot("1gf", 12.0, 11);
            factory.ProduceRobot("X", 10.0, 10);
            factory.ProduceRobot("1gf", 12.0, 11);
            Robot robot = factory.Robots.FirstOrDefault(r => r.Model == "X");
            var expectedOut = factory.SellRobot(10);
            Assert.That(expectedOut, Is.EqualTo(robot));

        }

    }
}