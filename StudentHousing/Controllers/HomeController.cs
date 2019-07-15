﻿using System;
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

namespace StudentHousing.Controllers
{
    public class HomeController : Controller
    {
        IApartmentService apartmentService = new ApartmentService();
        IRatingService ratingService = new RatingService();
        ICityService cityService = new CityService();
        public IActionResult Index(int cityId)
        {
            var allCities = cityService.GetAll();
            ApartmentsViewModel apartmentsViewModel = new ApartmentsViewModel();
            apartmentsViewModel.Cities = allCities.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            var apartments = apartmentService.GetApartmentsbyCity(cityId);
            apartmentsViewModel.Apartments = apartments.Select(x => new ApartmentModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                AvailableFrom = x.AvailableFrom,
                NumberOfBeds = x.NumberOfBeds,
                AverageRating = apartmentService.GetaverageRatingbyId(x.Id)
            }).ToList();
            

            return View(apartmentsViewModel);
        }
        [HttpGet]
        public IActionResult LoadListByCity(int id)
        {
            var apartments = apartmentService.GetApartmentsbyCity(id);
            ApartmentsViewModel apartmentsViewModel = new ApartmentsViewModel();
            apartmentsViewModel.Apartments = apartments.Select(x => new ApartmentModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                AvailableFrom = x.AvailableFrom,
                NumberOfBeds = x.NumberOfBeds,
                AverageRating = apartmentService.GetaverageRatingbyId(x.Id)
            }).ToList();
            return Json(apartmentsViewModel);

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
              //  return Json(new {Success = true, Message= "Apartment was succesfully created."});
            }
            return View();
        }
        [HttpGet]
        [Route("/about")]
        public IActionResult About()
        {

            //ViewData["Title"] = "Create Apartment";
            //return View();
            return Ok(cityService.GetAll().ToList());
        }
        [HttpPost]
        [Route("home/addrating")]
        public IActionResult AddRating(int ApartmentId, int RatingValue)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                var rating = new Rating
                {
                    RatingValue = RatingValue,
                    ApartmentId = ApartmentId
                };
                    var averageRating = ratingService.AddRating(rating);
                    return Json(new { Success = true, AverageRating = averageRating });
                //}
            }
            catch(Exception e)
            {
                return Json(new { Success = false, Message = "Validation Error" });
            }
            
            
                        
        }
        [HttpGet]
        [Route("/Privacy/{id}")]
        public IActionResult Privacy(int id)
        {

            //return Ok((List<Apartment>)apartmentService.SortbyRatingApartments());
            var list = apartmentService.SortbyPriceApartments(id).ToList();
            var listNmaes = new List<string>();
            foreach(var apt in list)
            {

                listNmaes.Add(apt.Name);
            }
            return Ok(listNmaes);

            //IEnumerable<Apartment> apartments = apartmentService.GetApartmentsbyCity(id);
            //if (apartments != null)
            //{
            //    foreach(var apt in apartments)
            //    {
            //        var datetime = apt.AvailableFrom;
            //        apt.AvailableFrom = datetime.Date;
            //    }
            //    return Ok(apartments);
            //}
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
