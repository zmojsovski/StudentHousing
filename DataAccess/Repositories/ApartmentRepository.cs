using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly SHContext _context;

        public ApartmentRepository(SHContext context)
        {
            _context = context;
        }
        public void Add(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
        }

        public IQueryable<Apartment> GetApartments()
        {
            return _context.Apartments.AsQueryable().Include(x => x.Ratings);
        }

        public IQueryable<Apartment> GetByCity(int id)
        {
            return _context.Apartments.Where(x => x.CityId == id).Include(x => x.Ratings);         
        }
    }
}
