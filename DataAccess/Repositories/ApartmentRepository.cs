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
        private  SHContext context = new SHContext();

        public void Add(Apartment apartment)
        {
            context.Apartments.Add(apartment);
        }

        public IEnumerable<Apartment> GetAll()
        {
            return context.Apartments.ToList();

        }

        public Apartment GetById(int Id)
        {
            return context.Apartments.FirstOrDefault(x => x.Id == Id);
          
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
