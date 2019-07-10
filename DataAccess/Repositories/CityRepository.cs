using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class CityRepository : ICityRepository
    {
       private  SHContext context = new SHContext();

        public City GetById(int Id)
        {
           
            return context.Cities.FirstOrDefault(x => x.Id == Id);
          
        }

        public void Save()
        {
            context.SaveChanges();
          
        }

        IEnumerable<City> ICityRepository.GetAll()
        {
            return context.Cities.ToList();
          
        }
    }
}
