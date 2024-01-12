using System;
using Microsoft.EntityFrameworkCore;
using P04.Models;

namespace P04
{
    public class ApplicationDBContext : DbContext
    {

        const string connectionString = "Server=.;Database=T04_MinionsDB;User Id=sa;Password=N45tejvWcK;TrustServerCertificate=True;";

        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}

