using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class RatingService : IRatingService
    {
        RatingRepository ratingRepository = new RatingRepository();
        ApartmentRepository apartmentRepository = new ApartmentRepository();
        public float AddRating(int singleRating, int aptId)
        {

            Rating rating = new Rating()
            {
                RatingValue = singleRating,
                ApartmentId = aptId,
                //Apartment = apartmentRepository.GetById(aptId)
            };
            ratingRepository.Add(rating);
            ratingRepository.Save();
            var ratingsByApartment = ratingRepository.GetAll().Where(x => x.ApartmentId == aptId);
            return ratingsByApartment.Sum(x => x.RatingValue) / ratingsByApartment.Count();

        }
        // try catch 



        public IEnumerable<Apartment> SortByRating()
        {
            throw new NotImplementedException();
        }
    }
}
