using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var accounts = Console.ReadLine()
            .Split(',')
            .Select(account =>
            {
                var parts = account.Split('-');
                var accountNumber = int.Parse(parts[0]);
                var balance = double.Parse(parts[1]);
                return new { Number = accountNumber, Balance = balance };
            })
            .ToDictionary(account => account.Number, account => account.Balance);

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "End")
            {
                break;
            }

            var parts = input.Split(' ');

            var command = parts[0];
            var accountNumber = int.Parse(parts[1]);

            if (!accounts.ContainsKey(accountNumber))
            {
                Console.WriteLine("Invalid account!");
                Console.WriteLine("Enter another command");
                continue;
            }

            var accountBalance = accounts[accountNumber];

            switch (command)
            {
                case "Deposit":
                    var depositAmount = double.Parse(parts[2]);
                    accountBalance += depositAmount;
                    accounts[accountNumber] = accountBalance;
                    Console.WriteLine($"Account {accountNumber} has new balance: {accountBalance:f2}");
                    Console.WriteLine("Enter another command");
                    break;

                case "Withdraw":
                    var withdrawAmount = double.Parse(parts[2]);
                    if (accountBalance < withdrawAmount)
                    {
                        Console.WriteLine("Insufficient balance!");
                        Console.WriteLine("Enter another command");
                        continue;
                    }
                    accountBalance -= withdrawAmount;
                    accounts[accountNumber] = accountBalance;
                    Console.WriteLine($"Account {accountNumber} has new balance: {accountBalance:f2}");
                    Console.WriteLine("Enter another command");
                    break;

                default:
                    Console.WriteLine("Invalid command!");
                    Console.WriteLine("Enter another command");
                    break;
            }
        }
    }
}
