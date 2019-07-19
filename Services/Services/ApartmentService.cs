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
   public class ApartmentService : IApartmentService
    {
        private IApartmentRepository _apartmentRepository;


        //private  SHContext context = new SHContext();
        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public void CreateApartment(Apartment apartment)
        {
          _apartmentRepository.Add(apartment);
        }

        public Apartment GetApartmentByName(string name)
        {
            return _apartmentRepository.GetApartments().FirstOrDefault(x => x.Name == name);          
        }

        public List<string> AutoComplete(int cityId, string nameSubstring)
        {
            IQueryable<Apartment> query = _apartmentRepository.GetByCity(cityId);
            if (!string.IsNullOrEmpty(nameSubstring))
            {
                var listOfAllNames = query.Select(x => x.Name).ToList();
                var compatibleNames = new List<string>();
                foreach(var aptName in listOfAllNames)
                {
                    if(aptName.Split(" ").Where(s => s.ToLower().StartsWith(nameSubstring.ToLower())).Count() != 0)
                        compatibleNames.Add(aptName);
                }
                return compatibleNames;
            }
            return null;
        }
        

        public IEnumerable<Apartment> SearchApartments(int cityId, string name, DateTime? availableFrom, int? numberOfBeds, string sortType, string sortDirection)
        {
            IQueryable<Apartment> query = _apartmentRepository.GetByCity(cityId);
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            if (availableFrom != null)
                query = query.Where(x => x.AvailableFrom.Date >= availableFrom.GetValueOrDefault().Date);
            if (numberOfBeds != null && numberOfBeds > 0)
                query = query.Where(x => x.NumberOfBeds >= numberOfBeds);

            query = query.ToList().AsQueryable();
            
            if (sortType == "price")
            {
                if (sortDirection == "down")
                    query = query.OrderBy(x => x.Price);
                else
                    query = query.OrderByDescending(x => x.Price);
            }
            else if (sortType == "rating")
            {
                if (sortDirection == "down")
                    query = query.OrderBy(x => x.AverageRating);
                else
                    query = query.OrderByDescending(x => x.AverageRating);
            }
            return query.ToList();
        }

    }
}
