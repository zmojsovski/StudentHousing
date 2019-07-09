using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    class RatingRepository : IRatingRepository
    {
        public SHContext _context;
        public List<Rating> GetAll()
        {
            throw new NotImplementedException();
        }

        public float GetById(int Id)
        {
            //get a list of Rating 
            //get sum of RatingValue
            //throw new NotImplementedException();
            return 0;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
