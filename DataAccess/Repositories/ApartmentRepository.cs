using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly SHContext _context;

        public ApartmentRepository(SHContext _context)
        {
            this._context = _context;
        }
        public void Add(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            throw new NotImplementedException();
        }

        public IEnumerable<Apartment> GetAll()
        {
            return _context.Apartments.ToList();
            throw new NotImplementedException();
        }

        public Apartment GetById(int Id)
        {
            return _context.Apartments.FirstOrDefault(x => x.Id == Id);
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
