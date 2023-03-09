using Models.Interfaces;

namespace P08_CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> data;

        public AddCollection()
        {
            data = new List<string>();
        }

        public int Add(string item)
        {
            data.Add(item);

            return data.Count - 1;
        }

    }
}
