using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IApartmentRepository
    {
        IQueryable<Apartment> GetApartments();
        //Apartment GetById(int Id);       
        void Add(Apartment apartment);
        IQueryable<Apartment> GetByCity(int id);
        //float GetAverageRating(int id);
    }
}
