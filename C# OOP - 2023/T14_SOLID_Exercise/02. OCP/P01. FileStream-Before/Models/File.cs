using P01._FileStream_Before.Interfaces;

namespace P01._FileStream_Before
{
    public abstract class File : IFile
    {
        protected File(string name, int length, int sent)
        {
            Name = name;
            Length = length;
            Sent = sent;
        }

        public string Name { get; set; }

        public int Length { get; set; }

        public int Sent { get; set; }
    }
}
