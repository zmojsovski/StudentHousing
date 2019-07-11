using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private SHContext context = new SHContext();

        public IEnumerable<Rating> GetRatingsById(int Id)
        {
            return context.Ratings.Where(x => x.Id == Id); 
        }

        public Rating Add(Rating rating)
        {
            context.Ratings.Add(rating);
            Save();
            return rating;
        }

        public void Save()
        {
            context.SaveChanges();
        }


        IEnumerable<Rating> IRatingRepository.GetAll()
        {
            return context.Ratings.ToList();
        }
    }
}
