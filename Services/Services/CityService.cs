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
        //private readonly ICityRepository _cityRepository;
        private IRepository<City> _repository;

        public CityService(IRepository<City> repository)
        {
            //_apartmentRepository = apartmentRepository;
            _repository = repository;
        }

        //public CityService(ICityRepository cityRepository)
        //{
        //    _cityRepository = cityRepository;
        //}

        public IQueryable<City> GetCities()
        {
            //return _cityRepository.GetCities().AsQueryable();
            return _repository.GetAll();

        }
    }
}
