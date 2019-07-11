using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IApartmentRepository
    {
        IEnumerable<Apartment> GetAll();
        Apartment GetById(int Id);
        void Save();
        Apartment Add(Apartment apartment);
        IEnumerable<Apartment> GetByCity(int id);
        IEnumerable<Apartment> SearchApartment(string name, Nullable<DateTime> availableFrom, Nullable<int> numberOfBeds);
        float GetAverageRating(int id);
        Dictionary<Apartment, float> GetByAverageRatingApartments();
    }
}
