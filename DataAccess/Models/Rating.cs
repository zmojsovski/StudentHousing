using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Services.Models
{
    [Table("Ratings")]
    public class Rating
    {
        [Key]
        int Id { get; set; }
        int RatingValue { get; set; }
        [ForeignKey("Apartment")]
        Apartment Apartment { get; set; }
        int ApartmentId { get; set; }
    }
}
