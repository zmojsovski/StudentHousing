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

        public float AddRating(Rating rating)
        {
            ratingRepository.Add(rating);
            ratingRepository.Save();
            var ratingsByApartment = ratingRepository.GetAll().Where(x => x.ApartmentId == rating.ApartmentId);
            return ratingsByApartment.Sum(x => x.RatingValue) / ratingsByApartment.Count();

        }
        // try catch 
       
       

        public IEnumerable<Apartment> SortByRating()
        {
            throw new NotImplementedException();
        }
    }
}
