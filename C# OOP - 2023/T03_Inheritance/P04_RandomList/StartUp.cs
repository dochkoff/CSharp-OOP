namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            RandomList list = new() { "A", "B", "C", "D", "F" };

            Console.WriteLine(list.RandomString());
        }
    }
}