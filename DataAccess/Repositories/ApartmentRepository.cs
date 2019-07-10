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

        public Apartment Add(Apartment apartment)
        {
            context.Apartments.Add(apartment);
            return apartment;
        }

        public IEnumerable<Apartment> GetAll()
        {
            return context.Apartments.ToList();

        }

        public IEnumerable<Apartment> GetByCity(int id)
        {
            return context.Apartments.Where(x => x.CityId == id).ToList();
        }

        public Apartment GetById(int Id)
        {
            return context.Apartments.FirstOrDefault(x => x.Id == Id);
          
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Apartment> SearchApartment(string name, DateTime availableFrom, int numberOfBeds)
        {
            return context.Apartments.Where(x => x.Name.Equals(name) && x.AvailableFrom.Equals(availableFrom)
            && x.NumberOfBeds == numberOfBeds).ToList();
        }
    }
}
