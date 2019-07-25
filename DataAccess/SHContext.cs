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
        public SHContext(DbContextOptions<SHContext> options) : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().HasOne<City>(s => s.City).WithMany(g => g.Apartments).HasForeignKey(s => s.CityId);
            modelBuilder.Entity<Apartment>().HasMany<Rating>(x => x.Ratings).WithOne(x => x.Apartment).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Cascade);
        }    
    }
}

