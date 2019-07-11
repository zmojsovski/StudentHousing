using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class RatingService : IRatingService
    {
        RatingRepository ratingRepository = new RatingRepository();

        public bool SendRating(Rating rating)
        {
            var newRating = ratingRepository.Add(rating);
            if (newRating != null)
            {
                return true;
            }
            return false;
        }

       

        public IEnumerable<Apartment> SortByRating()
        {
            throw new NotImplementedException();
        }
    }
}
