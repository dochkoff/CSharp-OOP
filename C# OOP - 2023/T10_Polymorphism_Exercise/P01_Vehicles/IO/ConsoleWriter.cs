using System;
using P01_Vehicles.IO.Interfaces;

namespace P01_Vehicles.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}

