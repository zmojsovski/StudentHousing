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
        private readonly SHContext _context;
        public RatingRepository(SHContext _context)
        {
            this._context = _context;
        }

        public float GetAverageById(int Id)
        {
            
            float sum = 0;
            List<Rating> ratings = _context.Ratings.Where(x => x.ApartmentId == Id).ToList();
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
            _context.SaveChanges();
            throw new NotImplementedException();
        }

        IEnumerable<Rating> IRatingRepository.GetAll()
        {
            return _context.Ratings.ToList();
            throw new NotImplementedException();
        }
    }
}
