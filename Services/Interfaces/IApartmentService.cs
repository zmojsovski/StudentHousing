using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IApartmentService
    {

        bool CreateApartment(Apartment apartment);
        IEnumerable<Apartment> SortbyPriceApartments();
        IEnumerable<Apartment> SearchApartments(String name, DateTime availableFrom, int numberOfBeds);
        IEnumerable<Apartment> GetApartmentsbyCity(int id);
    }
}
