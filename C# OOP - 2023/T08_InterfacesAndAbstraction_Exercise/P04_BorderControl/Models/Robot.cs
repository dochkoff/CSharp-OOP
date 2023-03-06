using System;
namespace P04_BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            ID = id;
        }

        public string Model { get; private set; }

        public string ID { get; private set; }
    }
}

