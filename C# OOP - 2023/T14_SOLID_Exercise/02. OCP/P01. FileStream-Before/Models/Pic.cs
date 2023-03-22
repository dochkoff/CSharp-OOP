using System;
using System.Xml.Linq;

namespace P01._FileStream_Before
{
    public class Pic : File
    {
        public Pic(string name, int length, int sent, int resolution)
            : base(name, length, sent)
        {
            Resolution = resolution;
        }

        public int Resolution { get; set; }
    }
}

