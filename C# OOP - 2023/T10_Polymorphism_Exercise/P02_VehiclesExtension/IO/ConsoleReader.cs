using System;
using P02_VehiclesExtension.IO.Interfaces;

namespace P02_VehiclesExtension.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}

