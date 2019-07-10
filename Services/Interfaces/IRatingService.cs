using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    interface IRatingService
    {
        IEnumerable<Apartment> SortByRating();
        float RatingAverage(int Id);
        bool SendRating(Rating rating);
    }
}
