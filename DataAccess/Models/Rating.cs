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
        public int Id { get; set; }
        [Required]
        [Range(1,5,ErrorMessage ="The Rating must be between 1 and 5")]
        public int RatingValue { get; set; }
        public Apartment Apartment { get; set; }
        [Required]
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
    }
}
