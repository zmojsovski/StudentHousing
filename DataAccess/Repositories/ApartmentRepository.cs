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

        public IQueryable<Apartment> GetAll()
        {
            return context.Apartments;

        }

        public float GetAverageRating(int id)
        {
            var ratings = context.Ratings.Where(x => x.ApartmentId == id).ToList();
            float sum = 0;
            foreach(var rating in ratings)
            {
                sum += rating.RatingValue;
            }
            return sum / ratings.Count;
        }

        public IQueryable<Apartment> GetByCity(int id)
        {
            return context.Apartments.Where(x => x.CityId == id);          
        }

        public Apartment GetById(int Id)
        {
            return context.Apartments.FirstOrDefault(x => x.Id == Id);
          
        }

        public IEnumerable<Apartment> SearchApartment(int cityId, string name, DateTime? availableFrom, int? numberOfBeds)
        {
            //vo service 
            //buildable query with condition
            return context.Apartments.Where(x => x.Name.Equals(name) && x.AvailableFrom.Equals(availableFrom)
            && x.NumberOfBeds == numberOfBeds).ToList();
        }

    }
}
