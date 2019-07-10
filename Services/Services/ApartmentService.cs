using DataAccess.Models;
using DataAccess.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
   public class ApartmentService : IApartmentService
    {
        ApartmentRepository apartmentRepository = new ApartmentRepository();
        public bool CreateApartment(Apartment apartment)
        {
            //if apartment in base: return true
            //Apartment apartment = ApartmentRepository.GetById();
            //mislam deka getApartment treba da vrakja bool vo ApartmentRepository
            var newApartment = apartmentRepository.Add(apartment);
            if (newApartment != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Apartment> GetApartmentsbyCity(int id)
        {
            return apartmentRepository.GetByCity(id);
        }

        public IEnumerable<Apartment> SearchApartments(string name, Nullable<DateTime> availableFrom, Nullable<int> numberOfBeds)
        {
            return apartmentRepository.SearchApartment(name, availableFrom, numberOfBeds);
        }

        public IEnumerable<Apartment> SortbyPriceApartments()
        {
            //var apartments = apartmentRepository.GetAll();
            //return from apt in apartments
            //       orderby apt.Price
            //       select apt;
            return null;
        }

        public IEnumerable<Apartment> SortbyRatingApartments()
        {
            //return from apt in apartmentRepository.GetAll()
            //       orderby apartmentRepository.GetAverageRating(apt.Id)
            //       select apt;
            return null;

        }
    }
}
