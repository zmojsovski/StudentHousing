﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataAccess.Models
{
    [Table("Apartments")]
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public DateTime AvailableFrom { get; set; }
        public int NumberOfBeds { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public List<Rating> Ratings { get; set; }
        [NotMapped]
        public float AverageRating
        {
            get
            {
                if (Ratings == null || Ratings.Count == 0)
                    return 0;
                return (float)Ratings.Sum(x =>
                    x.RatingValue) / Ratings.Count();
            }
    }
    }
}
