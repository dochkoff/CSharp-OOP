int number = int.Parse(Console.ReadLine());

try
{
    if (number >= 0)
    {
        Console.WriteLine(Math.Sqrt(number));
    }
    else
    {
        throw new ArgumentException("Invalid number.");
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}