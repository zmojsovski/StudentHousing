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
                NumberOfBedsList = GetNumberOfBeds(),
                Cities = GetAllCities(),
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
                    model.Cities = GetAllCities();
                    model.NumberOfBedsList = GetNumberOfBeds();
                    return View(model);
                }
                if(model.AvailableFrom < DateTime.Now)
                {
                    model.Cities = GetAllCities();
                    model.NumberOfBedsList = GetNumberOfBeds();
                    model.IsLowerDate = true;
                    return View(model);
                }
                var apartment = new Apartment
                {
                    Name = model.Name,
                    Address = model.Address,
                    Price = model.Price.GetValueOrDefault(),
                    NumberOfBeds = model.NumberOfBeds,
                    Description = model.Description,
                    Phone = model.Phone.ToString().Replace("-", ""),
                    CityId = model.CityId,
                    AvailableFrom = model.AvailableFrom.GetValueOrDefault()
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
                return RedirectToAction("Index", "Details", new { id = apartmentid.Id });
            }

            model.Cities = GetAllCities();
            model.NumberOfBedsList = GetNumberOfBeds();
            return View(model);
        }   
        public List<SelectListItem> GetNumberOfBeds() {
            var listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem { Text = "1", Value = "1" });
            listItems.Add(new SelectListItem { Text = "2", Value = "2" });
            listItems.Add(new SelectListItem { Text = "3", Value = "3" });
            listItems.Add(new SelectListItem { Text = "4", Value = "4" });
            return listItems;
        }

        public List<SelectListItem> GetAllCities()
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

        public DateTime GetTodaysDate()
        {
            DateTime today = DateTime.Today;
            return today.Date;
        }
    }
}
