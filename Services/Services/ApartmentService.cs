using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
   public class ApartmentService : IApartmentService
    {
        IApartmentRepository apartmentRepository = new ApartmentRepository();
        IRatingRepository ratingRepository = new RatingRepository();

        public void CreateApartment(Apartment apartment)
        {
          apartmentRepository.Add(apartment);
        }

        public IQueryable<Apartment> GetAll()
        {
            return apartmentRepository.GetAll();
        }

        public Apartment GetApartmentById(int id)
        {
            return apartmentRepository.GetById(id);
        }

        public Apartment GetApartmentByName(string name)
        {
            return apartmentRepository.GetAll().FirstOrDefault(x => x.Name == name);          
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

    }
}
