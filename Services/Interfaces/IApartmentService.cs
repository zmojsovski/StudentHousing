using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
    public interface IApartmentService
    {
        Apartment GetApartmentByName(string name);
        void CreateApartment(Apartment apartment);
        IEnumerable<Apartment> SearchApartments(int cityId, string name, DateTime? availableFrom, int? numberOfBeds, string sortType, string sortDirection);
        List<string> AutoComplete(int cityId, string nameSubstring);
    }
}
