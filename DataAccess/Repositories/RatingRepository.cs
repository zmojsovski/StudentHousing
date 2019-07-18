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

        public void Add(Rating rating)
        {
            context.Ratings.Add(rating);
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public IQueryable<Rating> GetRatings()
        {
            return context.Ratings.AsQueryable();
        }
    }
}
