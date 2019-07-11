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
            Save();
            return apartment;
        }

        public IEnumerable<Apartment> GetAll()
        {
            return context.Apartments.ToList();

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

        //public Dictionary<Apartment, float> GetByAverageRatingApartments()
        //{
        //    Dictionary<Apartment, float> ApartmentAvgRatingDict = new Dictionary<Apartment, float>();
        //    foreach(var apt in context.Apartments)
        //    {
        //        ApartmentAvgRatingDict.Add(apt, GetAverageRating(apt.Id));
        //    }
        //    return ApartmentAvgRatingDict;
        //}

        public IEnumerable<Apartment> GetByCity(int id)
        {
            return context.Apartments.Where(x => x.CityId == id).ToList();
            //return context.Apartments.ToList();
        }

        public Apartment GetById(int Id)
        {
            return context.Apartments.FirstOrDefault(x => x.Id == Id);
          
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Apartment> SearchApartment(string name, Nullable<DateTime> availableFrom, Nullable<int> numberOfBeds)
        {
            //vo service 
            //buildable query with condition
            return context.Apartments.Where(x => x.Name.Equals(name) && x.AvailableFrom.Equals(availableFrom)
            && x.NumberOfBeds == numberOfBeds).ToList();
        }

    }
}
