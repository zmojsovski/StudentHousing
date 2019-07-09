using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Services.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        int Id { get; set; }
        string Name { get; set; }
        ICollection<Apartment> Apartments { get; set; }
    }
}
