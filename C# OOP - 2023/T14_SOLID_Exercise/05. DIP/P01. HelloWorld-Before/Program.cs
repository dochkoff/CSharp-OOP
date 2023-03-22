using System;
using P01._HelloWorld;

namespace P01._HelloWorld_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld helloWorld = new();
            Console.WriteLine(helloWorld.Greeting("Dochkoff", DateTime.Now));
        }
    }
}
