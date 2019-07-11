using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Models
{
    public class RatingModel
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "The Rating must be between 1 and 5")]
        public int RatingValue  { get; set; }
        [Required]
        public int ApartmentId { get; set; }
    }
}
