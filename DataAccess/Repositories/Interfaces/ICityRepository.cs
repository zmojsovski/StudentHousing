using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICityRepository
    {
        IQueryable<City> GetCities();
    }
}
