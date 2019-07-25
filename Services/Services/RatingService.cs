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
        private IRepository<Rating> _repository;

        public RatingService(IRepository<Rating> repository)
        {
            _repository = repository;
        }

        public double AddRating(int ratingValue, int apartmentId)
        {
            Rating rating = new Rating()
            {
                RatingValue = ratingValue,
                ApartmentId = apartmentId,
            };
            _repository.Insert(rating);
            _repository.Save();

            var ratingsByApartment = _repository.GetAll().Where(x => x.ApartmentId == apartmentId);
            var average = (double)ratingsByApartment.Average(x => x.RatingValue);
            return Math.Round(average, 2);
        }
    }
}
