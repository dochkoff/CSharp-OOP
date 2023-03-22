using System;
using P01._FileStream_Before.Interfaces;

namespace P01._FileStream_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            IFile song = new Music("Escapism", 186, 37, "RAYE", "N/A");
            IFile pic = new Pic("Escapism", 144, 140, 1024);

            IProgress songProgress = new Progress(song);
            IProgress picProgress = new Progress(pic);

            Console.WriteLine(songProgress.CurrentPercent());
            Console.WriteLine(picProgress.CurrentPercent());
        }
    }
}