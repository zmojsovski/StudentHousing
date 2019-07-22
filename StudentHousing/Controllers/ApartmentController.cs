using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interfaces;
using Services.Services;
using StudentHousing.Models;

namespace StudentHousing.Controllers
{
    public class ApartmentController : Controller
    {
        public ApartmentController(IApartmentService apartmentService, ICityService cityService)
        {
            _apartmentService = apartmentService;
            _cityService = cityService;
        }

        private readonly IApartmentService _apartmentService;
        private readonly ICityService _cityService;

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
                    model.IsSuccess = true;
                }
                catch
                {
                    model.IsTryCatch = true;
                }
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
            var allCities = _cityService.GetCities();
        return    allCities.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public DateTime getTodayDate()
        {
            DateTime today = DateTime.Today;
            return today.Date;
        }
    }
}
