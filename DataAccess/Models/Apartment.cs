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
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public DateTime AvailableFrom { get; set; }
        public int NumberOfBeds { get; set; }
        public City City { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
