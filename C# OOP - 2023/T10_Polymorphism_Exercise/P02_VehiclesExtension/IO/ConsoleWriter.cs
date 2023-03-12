using System;
using P02_VehiclesExtension.IO.Interfaces;

namespace P02_VehiclesExtension.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}

