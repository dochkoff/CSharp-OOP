using System;

namespace P01._Square_Before
{
    public class Square : Shape
    {
        public override double Area => Math.Pow(this.Width, 2);

        public virtual double Width { get; set; }
    }
}
