public class StartUp
{
    static void Main()
    {
        Console.WriteLine(ReadNumber(1, 100));
    }

    static string ReadNumber(int start, int end)
    {
        int lastAddedNum = 1;
        List<int> enteredNums = new();

        while (enteredNums.Count < 10)
        {
            string input = Console.ReadLine();

            try
            {
                if (int.TryParse(input, out int num))
                {
                    if (1 < num && num < 100)
                    {
                        enteredNums.Add(num);
                        lastAddedNum = num;
                    }
                    else
                    {
                        throw new ArgumentException($"Your number is not in range {lastAddedNum} - 100!");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid Number!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return string.Join(", ", enteredNums);
    }
}