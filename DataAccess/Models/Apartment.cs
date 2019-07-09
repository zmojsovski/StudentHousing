using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    [Table("Apartments")]
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required",AllowEmptyStrings = false)]
        [StringLength(50,ErrorMessage = "Name can contain maximum 50 characters")]
        public string Name { get; set; }
        [StringLength(100,ErrorMessage ="Address can contain maximum 100 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Price per month must be inserted")]
        public decimal Price { get; set; }
        [StringLength(500,ErrorMessage ="Description is too long")]
        public string Description { get; set; }
        [StringLength(15,ErrorMessage ="Phone Number too long")]
        [RegularExpression("07[0-9]{7}")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Apartment Availability must be picked")]
        public DateTime AvailableFrom { get; set; }
        [Required]
        [Range(1,4,ErrorMessage ="The Number of Beds must be between 1 and 4")]
        public int NumberOfBeds { get; set; }
        public City City { get; set; }
        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
