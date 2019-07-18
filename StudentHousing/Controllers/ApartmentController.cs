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
        IApartmentService apartmentService = new ApartmentService();
        ICityService cityService = new CityService();
              
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ApartmentModel()
            {
                NumberOfBedsList = getNumberOfBeds(),
                Cities = getAllCities(),
                AvailableFrom = getTodayDate()
            };

            //  model.c

            return View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm] ApartmentModel model)
        {
            if (ModelState.IsValid)
            {
                var apt = apartmentService.GetApartmentByName(model.Name);
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
                    apartmentService.CreateApartment(apartment);
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
            var allCities = cityService.GetCities();
        return    allCities.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public DateTime getTodayDate()
        {
            DateTime today = DateTime.Today;
            return today;
        }
    }
}
