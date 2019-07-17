using DataAccess.Models;
using DataAccess.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
   public class ApartmentService : IApartmentService
    {
        ApartmentRepository apartmentRepository = new ApartmentRepository();
        RatingRepository ratingRepository = new RatingRepository();
        public void CreateApartment(Apartment apartment)
        {
          apartmentRepository.Add(apartment);
        }

        public IEnumerable<Apartment> GetAll()
        {
            return apartmentRepository.GetAll();
        }

        public Apartment GetApartmentById(int id)
        {
            return apartmentRepository.GetById(id);
        }

        public IEnumerable<Apartment> GetApartmentByName(string name)
        {
            var apartments = apartmentRepository.GetAll();
            var apartment = apartments.Where(x => x.Name == name);
            return apartment;
        }

        public IEnumerable<Apartment> GetApartmentsbyCity(int id)
        {
            return (apartmentRepository.GetByCity(id));
        }

        public float GetaverageRatingbyId(int id)
        {
            return apartmentRepository.GetAverageRating(id);
        }

        public IEnumerable<Apartment> SearchApartments(int cityId, string name, DateTime? availableFrom, int? numberOfBeds)
        {
            IQueryable<Apartment> query = apartmentRepository.GetByCity(cityId);
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (availableFrom != null)
            {
                query = query.Where(x => x.AvailableFrom.Date >= availableFrom.GetValueOrDefault().Date);
            }
            if (numberOfBeds != null && numberOfBeds > 0)
            {
                query = query.Where(x => x.NumberOfBeds >= numberOfBeds);
            }

            return query.ToList();
        }


        public IEnumerable<Apartment> SortbyPriceApartments(int flag)
        {
            //var apartments = apartmentRepository.GetAll();
            //return from apt in apartments
            //       orderby apt.Price
            //       select apt;
            var myList = apartmentRepository.GetAll().ToList();
            if (flag == 0)
                myList.Sort((x1, x2) => x1.Price.CompareTo(x2.Price));
            else
                myList.Sort((x1, x2) => x2.Price.CompareTo(x1.Price));
           
            
            return myList;
        }

        public IEnumerable<Apartment> SortbyRatingApartments(int flag)
        {
            

            Dictionary<Apartment, float> ApartmentAvgRatingDict = new Dictionary<Apartment, float>();

            var apartments = apartmentRepository.GetAll();
            var ratings = ratingRepository.GetAll();

            foreach(var apt in apartments)
            {
                var averageRating = ratings.Where(x => x.ApartmentId == apt.Id).Select(x => x.RatingValue).Average();
                ApartmentAvgRatingDict.Add(apt, (float)averageRating);
            }
            ApartmentAvgRatingDict.ToList().Sort((x1, x2) => x1.Value.CompareTo(x2.Value));
            return ApartmentAvgRatingDict.Keys;
        }
    }
}
