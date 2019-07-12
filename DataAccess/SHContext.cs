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
       //requires a value in the constructor for the repositories
        public SHContext(string connectionString = "Data Source=192.168.5.117;Database=StudentHousing;User Id=StudentHousing; Password=Student123@;") : base(GetOptions(connectionString))
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          /*  modelBuilder.Entity<City>()
                .HasMany<Apartment>(); */

            modelBuilder.Entity<Apartment>()
           .HasOne<City>(s => s.City)
           .WithMany(g => g.Apartments)
           .HasForeignKey(s => s.CityId);

        }
        
    }
}

