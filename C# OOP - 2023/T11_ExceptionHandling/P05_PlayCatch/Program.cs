
int[] sequence = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int catchCounter = 0;

while (catchCounter < 3)
{
    try
    {
        string[] cmdParams = Console.ReadLine()
        .Split();

        string commmand = cmdParams[0];

        if (commmand == "Replace")
        {
            int index = int.Parse(cmdParams[1]);
            int element = int.Parse(cmdParams[2]);

            sequence[index] = element;
        }
        else if (commmand == "Print")
        {
            int startIndex = int.Parse(cmdParams[1]);
            int endIndex = int.Parse(cmdParams[2]);

            if (startIndex < 0 || endIndex >= sequence.Length)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }
            int[] printArr = sequence.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();
            Console.WriteLine(string.Join(", ", printArr));

        }
        if (commmand == "Show")
        {
            int index = int.Parse(cmdParams[1]);

            Console.WriteLine(sequence[index]);
        }
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        catchCounter++;
    }
    catch (FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        catchCounter++;
    }
    catch (Exception)
    {
        Console.WriteLine("The index does not exist!");
        catchCounter++;
    }
}

Console.WriteLine(string.Join(", ", sequence));