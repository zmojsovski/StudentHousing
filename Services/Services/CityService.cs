using DataAccess.Models;
using DataAccess.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    class CityService : ICityService
    {
        CityRepository cityRepository = new CityRepository();

        public City GetCityById(int Id)
        {
            return cityRepository.GetById(Id);
        }
    }
}
