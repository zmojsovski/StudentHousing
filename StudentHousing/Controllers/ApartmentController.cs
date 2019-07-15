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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ApartmentModel model)
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
                    CityId = model.CityId

                };
                apartmentService.CreateApartment(apartment);
                //ViewData["Message"] = "Apartment has been created!";
                return Json(new { Message = "Apartment created!" });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewData["Title"] = "Create Apartment";
            return View();
        }
    }
}
