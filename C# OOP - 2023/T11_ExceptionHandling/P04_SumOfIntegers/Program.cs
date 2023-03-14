int sum = 0;

string[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var element in input)
{
    try
    {
        int nun = int.Parse(element);
        sum += nun;

    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{element}' is out of range!");
    }
    catch (FormatException fe)
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
}

Console.WriteLine($"The total sum of all integers is: {sum}");