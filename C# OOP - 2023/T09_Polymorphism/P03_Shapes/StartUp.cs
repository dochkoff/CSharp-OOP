using Shapes;

public class StartUp
{
    static void Main()
    {
        Shape rectangle = new Rectangle(3, 5);
        Shape circle = new Circle(12.4);

        Console.WriteLine(rectangle.CalculateArea());
        Console.WriteLine(circle.CalculatePerimeter());

        Console.WriteLine(rectangle.Draw());
    }
}