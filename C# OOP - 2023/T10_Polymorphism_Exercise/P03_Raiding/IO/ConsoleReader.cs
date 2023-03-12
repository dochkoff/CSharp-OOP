using System;
using P03_Raiding.IO.Interfaces;

namespace P03_Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}

