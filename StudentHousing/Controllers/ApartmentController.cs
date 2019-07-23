using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using Services.Services;
using StudentHousing.Models;

namespace StudentHousing.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly ICityService _cityService;
        private readonly ILogger<ApartmentController> _log;
        public ApartmentController(IApartmentService apartmentService, ICityService cityService, ILogger<ApartmentController> log)
        {
            _apartmentService = apartmentService;
            _cityService = cityService;
            _log = log;
        }

        

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ApartmentModel()
            {
                NumberOfBedsList = getNumberOfBeds(),
                Cities = getAllCities(),
                AvailableFrom = getTodayDate().Date
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm] ApartmentModel model)
        {
            if (ModelState.IsValid)
            {
                var apt = _apartmentService.GetApartmentByName(model.Name);
                if (apt != null)
                {
                    model.IsDuplicateName = true;
                    model.Cities = getAllCities();
                    model.NumberOfBedsList = getNumberOfBeds();
                    return View(model);
                }
                if(model.AvailableFrom < DateTime.Now)
                {
                    model.Cities = getAllCities();
                    model.NumberOfBedsList = getNumberOfBeds();
                    model.IsLowerDate = true;
                    return View(model);
                }
                var apartment = new Apartment
                {
                    Name = model.Name,
                    Address = model.Address,
                    Price = model.Price,
                    NumberOfBeds = model.NumberOfBeds,
                    Description = model.Description,
                    Phone = model.Phone,
                    CityId = model.CityId,
                    AvailableFrom = model.AvailableFrom
                };
                try
                {
                    _apartmentService.CreateApartment(apartment);
                }
                catch(Exception ex)
                {
                    model.IsTryCatch = true;
                    _log.LogWarning(ex, ex.Message);
                }
                var apartmentid = _apartmentService.GetApartmentByName(apartment.Name);
                return RedirectToAction("details", "Home", new { id = apartmentid.Id });
            }

            model.Cities = getAllCities();
            model.NumberOfBedsList = getNumberOfBeds();
            return View(model);
        }   
        public List<SelectListItem> getNumberOfBeds() {
            var listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem { Text = "1", Value = "1" });
            listItems.Add(new SelectListItem { Text = "2", Value = "2" });
            listItems.Add(new SelectListItem { Text = "3", Value = "3" });
            listItems.Add(new SelectListItem { Text = "4", Value = "4" });
            return listItems;
        }

        public List<SelectListItem> getAllCities()
        {
            var cities = new List<SelectListItem>();
            try
            {
              var  allCities = _cityService.GetCities();
              cities =  allCities.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            }
            catch(Exception ex)
            {
                _log.LogWarning(ex, ex.Message);
            }
            return cities;
        }

        public DateTime getTodayDate()
        {
            DateTime today = DateTime.Today;
            return today.Date;
        }
    }
}
