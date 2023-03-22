namespace P02._Books_Before
{
    using System;
    using P02._Books_Before.Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new Book("THE FUTURE OF ALMOST EVERYTHING", "Patrick Dixon", 57);

            IPageTurner pageTurner = new PageTurner();

            Console.WriteLine(pageTurner.TurnPage(book.Location));
        }
    }
}
