using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Models
{
    public class ApartmentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Name can contain maximum 50 characters")]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "Address can contain maximum 100 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Price per month is required")]
        [Range(0, 99999.99,ErrorMessage ="The Price can contain maximum 5 digits")]
        public decimal? Price { get; set; }
        [StringLength(500, ErrorMessage = "Description can contain maximum 500 characters")]
        public string Description { get; set; }
        [StringLength(11, ErrorMessage = "Phone Format invalid, please input the phone in the following format: 07X-XXX-XXX")]
        [RegularExpression("07[0-9]-*[0-9]{3}-*[0-9]{3}",ErrorMessage = "Phone number needs to be 07X-XXX-XXX")]
        public string Phone { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Apartment availability is required")]
        [DataType(DataType.Date)]
        public DateTime? AvailableFrom { get; set; }
        [Required]
        [Range(1, 4, ErrorMessage = "Please select the number of beds")]
        public int NumberOfBeds { get; set; }
        [Required]
        public int CityId { get; set; }
        public float AverageRating { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsDuplicateName { get; set; }

        public bool IsTryCatch { get; set; }

        public bool IsLowerDate { get; set; }

        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> NumberOfBedsList { get; set; }
    }
}
