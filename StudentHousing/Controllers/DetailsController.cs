using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using StudentHousing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentHousing.Controllers
{
    public class DetailsController : Controller
    {
        // GET: /<controller>/
        private readonly IApartmentService _apartmentService;
        private readonly IRatingService _ratingService;
        private readonly ICityService _cityService;
        private readonly ILogger<DetailsController> _log;

       // public IRatingService RatingService = _ratingService;

        public DetailsController(IApartmentService apartmentService, IRatingService ratingService, ICityService cityService, ILogger<DetailsController> log)
        {
            _apartmentService = apartmentService;
            _ratingService = ratingService;
            _cityService = cityService;
            _log = log;
        }
        [HttpGet]
        [Route("details")]
        public IActionResult Index(int id)
        {
            var model = GetApartmentModelById(id);
            return View(model);
        }
        private ApartmentModel GetApartmentModelById(int id)
        {
            ApartmentModel apartment = null;
            try
            {
                apartment = new ApartmentModel()
                {
                    Id = _apartmentService.GetApartmentById(id).Id,
                    Name = _apartmentService.GetApartmentById(id).Name,
                    Price = _apartmentService.GetApartmentById(id).Price,
                    AvailableFrom = _apartmentService.GetApartmentById(id).AvailableFrom,
                    NumberOfBeds = _apartmentService.GetApartmentById(id).NumberOfBeds,
                    AverageRating = float.Parse(_apartmentService.GetApartmentById(id).AverageRating.ToString("0.00")),
                    Phone = _apartmentService.GetApartmentById(id).Phone,
                    Description = _apartmentService.GetApartmentById(id).Description

                };
                if (apartment.Description == null || apartment.Description.Length == 0)
                {
                    apartment.Description = "No description available...";
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
            }
            return apartment;
        }
    }
}
