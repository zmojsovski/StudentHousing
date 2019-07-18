﻿using DataAccess.Models;
using DataAccess.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class CityService : ICityService
    {
        CityRepository cityRepository = new CityRepository();
        public IQueryable<City> GetCities()
        {
            return cityRepository.GetCities().AsQueryable();
        }
    }
}
