using Microsoft.EntityFrameworkCore;
using P04.Models;

namespace P04
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ApplicationDBContext db = new ApplicationDBContext();

            var townToDelete = await db.Towns.FirstOrDefaultAsync(t => t.Name == "New London");

            if (townToDelete != null)
            {
                db.Towns.Remove(townToDelete);
                db.SaveChanges();
            }

            //There is references between tables in the db. The program will trown an error.
        }
    }
}