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
              
        [HttpGet]
        public IActionResult Create()
        {
            //  var cities = cityService.get
            // select selectlistiteme
            var model = new ApartmentModel();
          //  model.c
            return View();
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
            return View(model);
        }      
    }
}
