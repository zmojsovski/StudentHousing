using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly SHContext _context;

        public CityRepository(SHContext context)
        {
            _context = context;
        }
        public IQueryable<City> GetCities()
        {
            return _context.Cities.AsQueryable();
        }
    }
}
