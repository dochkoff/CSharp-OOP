using System;
using P01._DrawingShape_Before.Contracts;

namespace P01._DrawingShape_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape rectangle = new Rectangle(10, 20);
            IRenderer renderer = new Renderer();
            IDrawingContext drawingContext = new DrawingContext();
            IDrawingManager drawingManager = new DrawingManager(drawingContext, renderer);

            drawingManager.Draw(rectangle);
        }
    }
}
