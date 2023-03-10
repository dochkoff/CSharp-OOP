namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value > 0)
                {
                    height = value;
                }
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
            }
        }
        public override double CalculateArea() => Height * Width;

        public override double CalculatePerimeter() => 2 * (Height + Width);
    }
}