using System;
namespace P01_Prototype.Models
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches = new();

        public SandwichPrototype this[string name]
        {
            get { return sandwiches[name]; }
            set { sandwiches.Add(name, value); }
        }
    }
}