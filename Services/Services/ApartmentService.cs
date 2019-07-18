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

        public void CreateApartment(Apartment apartment)
        {
          apartmentRepository.Add(apartment);
        }

        //public IQueryable<Apartment> GetApartments()
        //{
        //    return apartmentRepository.GetAll().AsQueryable();
        //}

        public Apartment GetApartmentByName(string name)
        {
            return apartmentRepository.GetApartments().FirstOrDefault(x => x.Name == name);          
        }

        //public IEnumerable<Apartment> GetApartmentsbyCity(int id)
        //{
        //    return (apartmentRepository.GetByCity(id));
        //}  

        public IEnumerable<Apartment> SearchApartments(int cityId, string name, DateTime? availableFrom, int? numberOfBeds, string sortType, string sortDirection)
        {
            IQueryable<Apartment> query = apartmentRepository.GetByCity(cityId);
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            if (availableFrom != null)
                query = query.Where(x => x.AvailableFrom.Date >= availableFrom.GetValueOrDefault().Date);
            if (numberOfBeds != null && numberOfBeds > 0)
                query = query.Where(x => x.NumberOfBeds >= numberOfBeds);

            query = query.ToList().AsQueryable();
            
            if (sortType == "price")
            {
                if (sortDirection == "down")
                    query = query.OrderBy(x => x.Price);
                else
                    query = query.OrderByDescending(x => x.Price);
            }
            else if (sortType == "rating")
            {
                if (sortDirection == "down")
                    query = query.OrderBy(x => x.AverageRating);
                else
                    query = query.OrderByDescending(x => x.AverageRating);
            }
            return query.ToList();
        }

    }
}
