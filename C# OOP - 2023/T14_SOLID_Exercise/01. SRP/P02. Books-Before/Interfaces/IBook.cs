using System;
namespace P02._Books_Before.Interfaces
{
    public interface IBook
    {
        public string Title { get; }

        public string Author { get; }

        public int Location { get; }
    }
}

