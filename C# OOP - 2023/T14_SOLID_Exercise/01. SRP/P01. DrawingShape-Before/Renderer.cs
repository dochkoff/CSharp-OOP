using System;
using P01._DrawingShape_Before.Contracts;

namespace P01._DrawingShape_Before
{
    public class Renderer : IRenderer
    {
        public Renderer()
        {
        }

        public void Render(IDrawingContext context, IShape shape)
        {
            Console.WriteLine(shape.Area);
        }
    }
}

