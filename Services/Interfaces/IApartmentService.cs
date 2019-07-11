﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IApartmentService
    {

        bool CreateApartment(Apartment apartment);
        IEnumerable<Apartment> SortbyPriceApartments(int flag);
        IEnumerable<Apartment> SearchApartments(string name, Nullable<DateTime> availableFrom, Nullable<int> numberOfBeds);
        IEnumerable<Apartment> GetApartmentsbyCity(int id);
        //IEnumerable<Apartment> SortbyRatingApartments(int flag);
    }
}
