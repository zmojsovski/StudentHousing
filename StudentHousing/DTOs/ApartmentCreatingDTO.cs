using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.DTOs
{
    public class ApartmentCreatingDTO
    {
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string Phone { get; set; }
        public DateTime AvailableFrom { get; set; }
        public int NumberOfBeds { get; set; }
        public int CityId { get; set; }
    }
}
