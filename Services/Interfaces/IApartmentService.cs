using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IApartmentService
    {

        bool CreateApartment();
        IEnumerable<Apartment> SortApartments();

    }
}
