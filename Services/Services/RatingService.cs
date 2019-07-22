using DataAccess;
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
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public double AddRating(int ratingValue, int apartmentId)
        {

            Rating rating = new Rating()
            {
                RatingValue = ratingValue,
                ApartmentId = apartmentId,
            };
            _ratingRepository.Add(rating);
            _ratingRepository.Save();

            var ratingsByApartment = _ratingRepository.GetRatings().Where(x => x.ApartmentId == apartmentId);
            var average = (double)ratingsByApartment.Average(x => x.RatingValue);
            return Math.Round(average, 2);
        }       
    }
}
