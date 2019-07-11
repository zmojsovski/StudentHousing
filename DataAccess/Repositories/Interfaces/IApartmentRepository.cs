using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IApartmentRepository
    {
        IEnumerable<Apartment> GetAll();
        Apartment GetById(int Id);
        void Save();
        Apartment Add(Apartment apartment);
        IQueryable<Apartment> GetByCity(int id);
        IEnumerable<Apartment> SearchApartment(int cityId, string name, Nullable<DateTime> availableFrom, Nullable<int> numberOfBeds);
        float GetAverageRating(int id);
        //Dictionary<Apartment, float> GetByAverageRatingApartments();
    }
}
