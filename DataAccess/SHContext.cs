using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess
{
   public class SHContext : DbContext
    {

       // private readonly string connectionString;
        public SHContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
           //     var builder = new ConfigurationBuilder()
          //  .SetBasePath(Directory.GetCurrentDirectory())
          
             //   optionsBuilder.UseSqlServer(ConfigurationManager);
            }
        }



        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}
