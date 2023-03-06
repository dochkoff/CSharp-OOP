using System;
namespace P03_Telefony.Models
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(c => char.IsDigit(c)))
            {
                Console.WriteLine("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}