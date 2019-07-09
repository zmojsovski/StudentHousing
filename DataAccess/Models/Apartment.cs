using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Services.Models
{
    [Table("Apartments")]
    public class Apartment
    {
        [Key]
        int Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        decimal Price { get; set; }
        string Description { get; set; }
        string Phone { get; set; }
        DateTime AvailableFrom { get; set; }
        int NumberOfBeds { get; set; }
        City City { get; set; }
        int CityId { get; set; }
        ICollection<Rating> Ratings { get; set; }
    }
}
