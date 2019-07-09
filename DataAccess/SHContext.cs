using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
   public class SHContext : DbContext
    {
        public SHContext(DbContextOptions<SHContext> options) : base(options) { }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}
