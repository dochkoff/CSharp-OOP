using Microsoft.EntityFrameworkCore;
using P02.Models;

namespace P02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDBContext db = new ApplicationDBContext();

            Country country = new Country { Name = "Doch" };
            db.Countries.Add(country);
            db.SaveChanges();



            var towns = db.Towns
                .Include(t => t.Country);
        }
    }
}