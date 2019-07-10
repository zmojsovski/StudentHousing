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

        public float GetAverageById(int Id)
        {
            
            float sum = 0;
            List<Rating> ratings = context.Ratings.Where(x => x.ApartmentId == Id).ToList();
            foreach (Rating r in ratings)
            {
                sum += Convert.ToSingle(r.RatingValue);
                    //sum += float.Parse(r.RatingValue.ToString());
            }
            //ratings.ForEach(x => float.Parse(x.RatingValue)).ToList().Sum();
            return sum / ratings.Count;
            //throw new NotImplementedException();
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
