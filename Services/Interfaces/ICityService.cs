using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICityService
    {
        IEnumerable<City> GetAll();
    }
}
