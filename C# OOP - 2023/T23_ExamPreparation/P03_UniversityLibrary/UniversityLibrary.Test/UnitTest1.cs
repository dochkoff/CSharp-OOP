namespace UniversityLibrary.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    public class Tests
    {
        TextBook book;
        UniversityLibrary lib;
        string title;
        string author;
        string category;
        int inventoryNumber;
        string holder;

        [SetUp]
        public void Setup()
        {
            title = "1";
            author = "2";
            category = "3";
            inventoryNumber = 4;
            holder = null;

            book = new(title, author, category);
            lib = new();
        }

        [TearDown]
        public void TearDown()
        {
            book = null;
            lib = null;
        }

        [Test]
        public void TextBookConstructorTest()
        {
            Assert.That(title, Is.EqualTo(book.Title));
            Assert.That(author, Is.EqualTo(book.Author));
            Assert.That(category, Is.EqualTo(book.Category));

            Assert.That(holder, Is.EqualTo(book.Holder));
        }

        [Test]
        public void TextBookSetInventoryNumber()
        {
            book.InventoryNumber = inventoryNumber;
            Assert.That(inventoryNumber, Is.EqualTo(book.InventoryNumber));
        }

        [Test]
        public void TextBookSetHolder()
        {
            string desiredHolder = "5";
            book.Holder = desiredHolder;


            Assert.That(desiredHolder, Is.EqualTo(book.Holder));
        }

        [Test]
        public void TextBookToStringOverride()
        {
            book.InventoryNumber = inventoryNumber;
            string expextedOutput = $"Book: {title} - {inventoryNumber}{Environment.NewLine}Category: {category}{Environment.NewLine}Author: {author}";

            Assert.That(expextedOutput, Is.EqualTo(book.ToString()));
        }

        [Test]
        public void UniversityLibraryCatalogueAndAddTextBook()
        {
            string result = lib.AddTextBookToLibrary(book);
            string expextedOutput = $"Book: 1 - 1{Environment.NewLine}Category: 3{Environment.NewLine}Author: 2";

            Assert.That(lib.Catalogue.Contains(book));
            Assert.That(1, Is.EqualTo(book.InventoryNumber));
            Assert.That(1, Is.EqualTo(lib.Catalogue.Count));
            Assert.That(lib.Catalogue[0].Title, Is.EqualTo(book.Title));
            Assert.That(expextedOutput, Is.EqualTo(result));

        }



        [Test]
        public void UniversityLibraryLoanTextBook()
        {

            lib.AddTextBookToLibrary(book);
            Assert.That(book.Holder, Is.EqualTo(null));

            string studentName = "Papi";
            inventoryNumber = 1;
            string result = lib.LoanTextBook(inventoryNumber, studentName);
            string expectedOutput = $"1 loaned to Papi.";

            Assert.That(book.Holder, Is.EqualTo(studentName));
            Assert.That(expectedOutput, Is.EqualTo(result));
        }

        [Test]
        public void UniversityLibraryLoanTextBookHasntReturned()
        {
            string studentName = "Papi";
            book.Holder = studentName;
            inventoryNumber = 1;
            lib.AddTextBookToLibrary(book);
            string result = lib.LoanTextBook(inventoryNumber, studentName);
            string expectedOutput = $"{studentName} still hasn't returned {book.Title}!";

            Assert.That(expectedOutput, Is.EqualTo(result));
            Assert.That(studentName, Is.EqualTo(book.Holder));
        }

        [Test]
        public void UniversityLibraryReturnTextBook()
        {
            lib.AddTextBookToLibrary(book);
            inventoryNumber = 1;
            string result = lib.ReturnTextBook(inventoryNumber);
            string expectedOutput = $"{book.Title} is returned to the library.";
            string expectedHolder = string.Empty;

            Assert.That(expectedOutput, Is.EqualTo(result));
            Assert.That(expectedHolder, Is.EqualTo(book.Holder));
        }
    }
}