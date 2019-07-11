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
            var myList = apartmentRepository.GetByAverageRatingApartments().ToList();
            myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            List<Apartment> apartments = new List<Apartment>();
            foreach(var apt in myList)
            {
                apartments.Add(apt.Key);
            }
            return apartments;
        }
    }
}
