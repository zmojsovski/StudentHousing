using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Models
{
    public class RatingModel
    {
        public int Id { get; set; }
        public int RatingValue  { get; set; }
        public int ApartmentId { get; set; }
    }
}
