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
        //private readonly IRatingRepository _ratingRepository;
        private IRepository<Rating> _repository;

        public RatingService(IRepository<Rating> repository)
        {
            //_apartmentRepository = apartmentRepository;
            _repository = repository;
        }
        //public RatingService(IRatingRepository ratingRepository)
        //{
        //    _ratingRepository = ratingRepository;
        //}
        public double AddRating(int ratingValue, int apartmentId)
        {
            Rating rating = new Rating()
            {
                RatingValue = ratingValue,
                ApartmentId = apartmentId,
            };
            //_ratingRepository.Add(rating);
            //_ratingRepository.Save();
            _repository.Insert(rating);
            _repository.Save();

            //var ratingsByApartment = _ratingRepository.GetRatings().Where(x => x.ApartmentId == apartmentId);
            var ratingsByApartment = _repository.GetAll().Where(x => x.ApartmentId == apartmentId);
            var average = (double)ratingsByApartment.Average(x => x.RatingValue);
            return Math.Round(average, 2);
        }       
    }
}
