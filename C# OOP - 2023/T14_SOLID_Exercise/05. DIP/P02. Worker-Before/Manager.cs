namespace P02._Worker_Before
{
    public class Manager : IEmployee
    {
        public void Work()
        {
            IEmployee worker = new Worker();
            worker.Work();
        }
    }
}