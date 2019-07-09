using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class SHContext : DbContext
    {
        public SHContext(DbContextOptions<SHContext> options) : base(options) { }

        DbSet<Apartment> Apartments { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Rating> Ratings { get; set; }
    }
}
