using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    [Table("Ratings")]
    public class Rating
    {
        public int Id { get; set; }

        public int RatingValue { get; set; }
        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
    }
}
