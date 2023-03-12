using System;
using P04_WildFarm.IO.Interfaces;

namespace P04_WildFarm.IO;

public class ConsoleReader : IReader
{
    public string ReadLine()
        => Console.ReadLine();
}
