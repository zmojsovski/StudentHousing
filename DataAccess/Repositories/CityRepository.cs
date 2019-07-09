using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    class CityRepository : ICityRepository
    {
        public SHContext _context;

        public List<City> GetAll()
        {
            throw new NotImplementedException();
        }

        public City GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
