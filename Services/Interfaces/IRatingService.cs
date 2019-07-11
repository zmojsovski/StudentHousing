using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    interface IRatingService
    {
        IEnumerable<Apartment> SortByRating();
        bool SendRating(Rating rating);
    }
}
