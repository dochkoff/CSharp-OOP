namespace DatabaseExtended.Tests
{
    using System;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
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
        public void CreateDatabase() //ctor & AddRange
        {

            database = new Database(new Person(1, "UserName"));
            Person result = database.FindById(1);

            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.UserName, Is.EqualTo("UserName"));
        }

        [Test]
        public void CountProperty() //Count
        {
            database = new Database(new Person(1, "UserName"));

            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethod()
        {
            database = new Database();
            database.Add(new Person(1, "Pavel"));
            Person result = database.FindById(1);

            Assert.That(database.Count, Is.EqualTo(1));
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.UserName, Is.EqualTo("Pavel"));
        }

        [Test]
        public void ShouldThrowIfMoreThanSixteenPersons()
        {
            Person[] people = CreateBiggerArray();

            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => database = new Database(people));

            Assert.That(exception.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void ShouldThrowIfExcidedMaximumCapacity()
        {
            Person[] people = CreateFullArray();
            database = new Database(people);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "UserName")));

            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void ShouldThrowIfAddPersonWithSameUserName()
        {
            database = new Database(new Person(1, "Pavel"));

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Pavel")));

            Assert.That(exception.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void ShouldThrowIfAddPersonWithSameId()
        {
            database = new Database(new Person(1, "Pavel"));

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Martin")));

            Assert.That(exception.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveMethodTets()
        {
            database = new Database(new Person(1, "Pavel"));
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldThrowIfRemoveFromEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(database.Remove);
        }

        [Test]
        public void ReturnUserByUsername()
        {
            database = new Database(new Person(1, "Pavel"));
            Person person = database.FindByUsername("Pavel");

            Assert.That(person.UserName, Is.EqualTo("Pavel"));
        }

        [Test]
        public void ShouldThrowIfSearchNameIsNullOrEmpty()
        {
            ArgumentNullException exception1 =
                Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.That(exception1.ParamName, Is.EqualTo("Username parameter is null!"));

            ArgumentNullException exception2 =
                Assert.Throws<ArgumentNullException>(() => database.FindByUsername(string.Empty));
            Assert.That(exception2.ParamName, Is.EqualTo("Username parameter is null!"));
        }

        [Test]
        public void ShouldThrowIfUserDoesNotExist()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Pavel"));
            Assert.That(exception.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void ReturnUserById()
        {
            database = new Database(new Person(1, "Pavel"));
            Person person = database.FindById(1);

            Assert.That(person.Id, Is.EqualTo(1));
        }

        [Test]
        public void ShouldThrowIfIdIsBelowZero()
        {
            ArgumentOutOfRangeException exception =
                Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
            Assert.That(exception.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void ShouldThrowIfNoPersonWithSuchId()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.FindById(1));
            Assert.That(exception.Message, Is.EqualTo("No user is present by this ID!"));
        }


        private Person[] CreateFullArray()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            return persons;
        }

        private Person[] CreateBiggerArray()
        {
            Person[] persons = new Person[17];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            return persons;
        }
    }
}