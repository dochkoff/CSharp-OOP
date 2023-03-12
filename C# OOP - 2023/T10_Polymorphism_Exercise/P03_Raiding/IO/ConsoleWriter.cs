using System;
using P03_Raiding.IO.Interfaces;

namespace P03_Raiding.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}

