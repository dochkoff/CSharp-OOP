using P02._Books_Before.Interfaces;

namespace P02._Books_Before
{
    public class Book : IBook
    {
        public Book(string title, string author, int location)
        {
            Title = title;
            Author = author;
            Location = location;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Location { get; set; }
    }
}
