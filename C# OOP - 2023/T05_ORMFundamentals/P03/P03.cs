using Microsoft.EntityFrameworkCore;
using P03.Models;

namespace P03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ApplicationDBContext db = new ApplicationDBContext();

            var townToEdit = await db.Towns.FirstOrDefaultAsync(t => t.Name == "London");

            if (townToEdit != null)
            {
                townToEdit.Name = "New London";
                db.SaveChanges();
            }
        }
    }
}