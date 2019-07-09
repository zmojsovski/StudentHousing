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
        
        public CityRepository(SHContext _context)
        {
            this._context = _context;
        }

        public City GetById(int Id)
        {
           
            return _context.Cities.FirstOrDefault(x => x.Id == Id);
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
            throw new NotImplementedException();
        }

        IEnumerable<City> ICityRepository.GetAll()
        {
            return _context.Cities.ToList();
            throw new NotImplementedException();
        }
    }
}
