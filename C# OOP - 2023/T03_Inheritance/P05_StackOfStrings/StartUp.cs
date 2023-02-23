namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            StackOfStrings customStack = new();
            Console.WriteLine(customStack.IsEmpty());

            List<string> list = new() { "A", "B", "C", "D", "F" };
            customStack.AddRange(list);
            Console.WriteLine(customStack.IsEmpty());

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}