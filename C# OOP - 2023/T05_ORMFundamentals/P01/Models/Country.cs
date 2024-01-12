using System;
namespace P01.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<Town>? Towns { get; set; }
    }
}

