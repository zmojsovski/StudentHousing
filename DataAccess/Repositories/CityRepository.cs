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
       private  SHContext context = new SHContext();
        public IQueryable<City> GetCities()
        {
            return context.Cities.AsQueryable();
        }
    }
}
