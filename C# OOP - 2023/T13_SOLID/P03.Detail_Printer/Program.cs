using System.Collections.Generic;
using System.Reflection.Metadata;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IEmployee employee = new Employee("Ivan");

            List<string> documentsCollection = new List<string>() { "doc1", "doc2", "doc3" };
            IEmployee manager = new Manager("Stefan", documentsCollection);

            List<IEmployee> employees = new() { employee, manager };

            DetailsPrinter detailsPrinter = new(employees);

            detailsPrinter.PrintDetails();
        }
    }
}
