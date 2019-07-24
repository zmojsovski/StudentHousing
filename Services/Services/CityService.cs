using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class CityService : ICityService
    {
        private IRepository<City> _repository;

        public CityService(IRepository<City> repository)
        {
            _repository = repository;
        }

        public IQueryable<City> GetCities()
        {
            return _repository.GetAll();
        }
    }
}
