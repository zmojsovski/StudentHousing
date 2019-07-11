using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Models
{
    public class ApartmentsViewModel
    {
        public List<ApartmentModel> Apartments { get; set; }
        public List<CityModel> Cities { get; set; }
    }
}
