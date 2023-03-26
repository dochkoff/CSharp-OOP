namespace Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [TearDown]
        public void TearDown()
        {
            database = null;
        }

        [Test]
        public void CreateDatabaseWithFiveElements()
        {
            database = new Database(1, 2, 3, 4, 5);

            Assert.AreEqual(5, database.Count);
        }

        [Test]
        public void AddMethodTets()
        {
            database.Add(3);
            int[] result = database.Fetch();

            Assert.That(1, Is.EqualTo(database.Count));
            Assert.That(1, Is.EqualTo(result.Length));
            Assert.That(3, Is.EqualTo(result[0]));
        }

        [Test]
        public void RemoveMethodTets()
        {
            database = new Database(1, 2, 3);
            database.Remove();
            int[] result = database.Fetch();

            Assert.That(2, Is.EqualTo(database.Count));
            Assert.That(2, Is.EqualTo(result.Length));
            Assert.That(2, Is.EqualTo(result[1]));
        }

        [Test]
        public void FatchDataFromDatabase()
        {
            database = new Database(1, 2, 3);
            int[] result = database.Fetch();

            Assert.That(new int[] { 1, 2, 3 }, Is.EquivalentTo(result));
        }

        [Test]
        public void ShouldThrowIfExcidedMaximumCapacity()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(17));

            Assert.That("Array's capacity must be exactly 16 integers!", Is.EqualTo(exception.Message));
        }

        [Test]
        public void ShouldThrowIfTryRemoveFromEmptyDatabase()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(database.Remove);

            Assert.That("The collection is empty!", Is.EqualTo(exception.Message));
        }
    }
}