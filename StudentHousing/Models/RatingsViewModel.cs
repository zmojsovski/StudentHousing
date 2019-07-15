using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Models
{
    public class RatingsViewModel
    {
        public int ApartmentId { get; set; }
        public List<RatingModel> Ratings{ get; set; }
        public List<SelectListItem> Apartment { get; set; }
    }
}
