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
        private  SHContext context = new SHContext();

        public void Add(Apartment apartment)
        {
            context.Apartments.Add(apartment);
            context.SaveChanges();
        }

        public IQueryable<Apartment> GetApartments()
        {
            return context.Apartments.AsQueryable();
        }

        public IQueryable<Apartment> GetByCity(int id)
        {
            return context.Apartments.Where(x => x.CityId == id).Include(x => x.Ratings);         
        }
    }
}
