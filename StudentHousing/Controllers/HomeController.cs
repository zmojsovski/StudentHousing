using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentHousing.Models;
using DataAccess.Models;
using Services.Services;
using Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;

namespace StudentHousing.Controllers
{
    public class HomeController : Controller
    {
        ApartmentsViewModel apartmentsViewModel = new ApartmentsViewModel();
        private readonly IApartmentService _apartmentService;
        private readonly IRatingService _ratingService;
        private readonly ICityService _cityService;
        private readonly ILogger<HomeController> _log;
        public HomeController(IApartmentService apartmentService, IRatingService ratingService, ICityService cityService, ILogger<HomeController> log)
        {
            _apartmentService = apartmentService;
            _ratingService = ratingService;
            _cityService = cityService;
            _log = log;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ApartmentsViewModel model = null;
            try
            {
                var allCities = _cityService.GetCities();
                apartmentsViewModel.Cities = allCities.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                model = this.GetFullAndPartialViewModel(allCities.FirstOrDefault().Id);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
            }
            
            return this.View(model);
        }

        [HttpPost]
        [Route("home/searchautocomplete")]
        public JsonResult SearchAutoComplete(int cityId, string nameSubstring)
        {
            var names = new List<string>();
            try
            {
                names = _apartmentService.AutoComplete(cityId, nameSubstring).ToList();
            }
            catch(Exception ex) {
                _log.LogError(ex, ex.Message);
            }
            return Json(names);
        }

        private ApartmentsViewModel GetFullAndPartialViewModel(int? cityId, string name = null, DateTime? availableFrom = null, int? numberOfBeds = null, string sortType = null, string sortDirection = null)
        {
            try
            {
                if (availableFrom == DateTime.MinValue)
                    availableFrom = null;
                apartmentsViewModel.Apartments = _apartmentService.SearchApartments(cityId.GetValueOrDefault(), name, availableFrom, numberOfBeds, sortType, sortDirection)
                     .Select(x => new ApartmentModel
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Price = x.Price,
                         AvailableFrom = x.AvailableFrom,
                         NumberOfBeds = x.NumberOfBeds,
                         AverageRating = float.Parse(x.AverageRating.ToString("0.00"))
                     }).ToList();
            }
            catch(Exception ex)
            {
                _log.LogError(ex, ex.Message);
            }
            return apartmentsViewModel;    
        }

        [HttpGet]
        [Route("home/getapartmentsbysearch")]
        public IActionResult GetApartmentsBySearch([FromQuery]int cityId, [FromQuery]string name, [FromQuery]DateTime availableFrom, [FromQuery]int numberOfBeds, string sortType, string sortDirection)
        {
            ApartmentsViewModel model = null;
            try
            {
                model = this.GetFullAndPartialViewModel(cityId, name, availableFrom, numberOfBeds, sortType, sortDirection);
            }
            catch(Exception ex)
            {
                _log.LogError(ex, ex.Message);
            }
            return PartialView("_ListApartments", model);
        }

        [HttpPost]
        [Route("home/addrating")]
        public IActionResult AddRating(int apartmentId, int ratingValue)
        {
            try
            {
                var avgRating = _ratingService.AddRating(ratingValue, apartmentId);
                return Json(new { success = true, avgRating = avgRating });
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return Json(new { success = false, avgRating = 0 });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
