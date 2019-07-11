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
        public bool CreateApartment(Apartment apartment)
        {
            //if apartment in base: return true
            //Apartment apartment = ApartmentRepository.GetById();
            //mislam deka getApartment treba da vrakja bool vo ApartmentRepository
         

          apartmentRepository.Add(apartment);
           
        }

        public IEnumerable<Apartment> GetApartmentsbyCity(int id)
        {
            return apartmentRepository.GetByCity(id);
        }

        public IEnumerable<Apartment> SearchApartments(string name, DateTime? availableFrom, int? numberOfBeds)
        {
            return apartmentRepository.SearchApartment(name, availableFrom, numberOfBeds);
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
            //var myList = apartmentRepository.GetByAverageRatingApartments().ToList();
            //if(flag == 0)
            //    myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            //else
            //    myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            //List<Apartment> apartments = new List<Apartment>();
            //foreach(var apt in myList)
            //{
            //    apartments.Add(apt.Key);
            //}
            //return apartments;

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
