using P03_Telefony;
using P03_Telefony.Models;

string[] phoneNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] websites = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

foreach (var phoneNumber in phoneNumbers)
{
    ICallable phone;

    if (phoneNumber.Length == 10)
    {
        phone = new Smartphone();
    }
    else
    {
        phone = new StationaryPhone();
    }

    Console.WriteLine(phone.Call(phoneNumber));
}

foreach (var website in websites)
{
    IBrowsable smartPhone = new Smartphone();

    Console.WriteLine(smartPhone.Browse(website));
}