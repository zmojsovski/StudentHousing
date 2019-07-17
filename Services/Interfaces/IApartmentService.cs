using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
    public interface IApartmentService
    {
        float GetaverageRatingbyId(int id);

        IQueryable<Apartment> GetAll();

        Apartment GetApartmentByName(string name);
        void CreateApartment(Apartment apartment);
        IEnumerable<Apartment> SortbyPriceApartments(int flag);
        IEnumerable<Apartment> SearchApartments(int cityId, string name, DateTime? availableFrom, int? numberOfBeds);
        IEnumerable<Apartment> GetApartmentsbyCity(int id);
        //IEnumerable<Apartment> SortbyRatingApartments(int flag);
        Apartment GetApartmentById(int id);
    }
}
