using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetAll();
        float GetAverageById(int Id);
        Rating Add(Rating rating);
        void Save();
    }
}
