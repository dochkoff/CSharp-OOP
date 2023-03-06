using System;
namespace P03_Telefony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {
        }

        public string Browse(string website)
        {
            if (!website.All(c => !Char.IsDigit(c)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {website}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(char.IsDigit))
            {
                return "Invalid number!";
            }

            return $"Calling... {phoneNumber}";
        }
    }
}

