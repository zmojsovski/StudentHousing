using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;
using StudentHousing.Models;

namespace StudentHousing.Controllers
{
    public class ApartmentController : Controller
    {
        IApartmentService apartmentService = new ApartmentService();
        ICityService cityService = new CityService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] ApartmentModel model)
        {
            if (ModelState.IsValid)
            {
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
                var apt = apartmentService.GetApartmentByName(apartment.Name);
                if (!(apt != null))
                {
                    apartmentService.CreateApartment(apartment);
                    //   return Json(new {Success = true, Message= "Apartment was succesfully created."});
                    ViewBag.Success = "Apartment successfully Created!";
                }
                ViewBag.Error = "Apartment Name Taken!";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewData["Title"] = "Create Apartment";
            var cities = cityService.GetAll();
            var broj = cities.Count();
            ViewBag.cities = cities;
            ViewBag.brojac = broj;
            return View();
        }
    }
}
