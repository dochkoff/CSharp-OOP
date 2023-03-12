using System;
using P04_WildFarm.IO.Interfaces;

namespace P04_WildFarm.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(object obj)
        => Console.WriteLine(obj);
}
