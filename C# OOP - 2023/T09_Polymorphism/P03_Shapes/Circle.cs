namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => radius;
            private set
            {
                if (value > 0)
                {
                    radius = value;
                }
            }
        }

        public override double CalculateArea() => Math.PI * Math.Pow(this.Radius, 2);

        public override double CalculatePerimeter() => 2 * Math.PI * Radius;
    }
}

