using System;
namespace Cars.Models
{
    public interface ICar
    {
        public string Model { get; }
        public string Color { get; }

        public string Start();
        public string Stop();
    }
}

