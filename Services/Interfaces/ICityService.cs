using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
    public interface ICityService
    {
        IQueryable<City> GetCities();
    }
}
