using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        void Save();
        void Add(Rating rating);
        IQueryable<Rating> GetRatings();
    }
}
