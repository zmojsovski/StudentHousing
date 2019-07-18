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
        public double AddRating(int ratingValue, int apartmentId)
        {

            Rating rating = new Rating()
            {
                RatingValue = ratingValue,
                ApartmentId = apartmentId,
            };
            ratingRepository.Add(rating);
            ratingRepository.Save();

            var ratingsByApartment = ratingRepository.GetRatings().Where(x => x.ApartmentId == apartmentId);
            var average = (double)ratingsByApartment.Sum(x => x.RatingValue) / ratingsByApartment.Count();
            return Math.Round(average, 2);
        }       
    }
}
