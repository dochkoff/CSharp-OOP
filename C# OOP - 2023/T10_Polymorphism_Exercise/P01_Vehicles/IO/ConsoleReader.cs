using System;
using P01_Vehicles.IO.Interfaces;

namespace P01_Vehicles.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}

