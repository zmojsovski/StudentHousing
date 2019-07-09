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
        [Key]
        int Id { get; set; }
        int RatingValue { get; set; }
        Apartment Apartment { get; set; }
        [ForeignKey("Apartment")]
        int ApartmentId { get; set; }
    }
}
