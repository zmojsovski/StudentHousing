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
using Microsoft.AspNetCore.Cors;

namespace StudentHousing.Controllers
{
    public class HomeController : Controller
    {
        IApartmentService apartmentService = new ApartmentService();
        IRatingService ratingService = new RatingService();
        ICityService cityService = new CityService();
        ApartmentsViewModel apartmentsViewModel = new ApartmentsViewModel();
        
        [HttpGet]
        public IActionResult Index()
        {
            var allCities = cityService.GetAll();
            apartmentsViewModel.Cities = allCities.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            var model = this.GetFullAndPartialViewModel(allCities.FirstOrDefault().Id, null, null, null, null, null);
            return this.View(model);
        }

        private ApartmentsViewModel GetFullAndPartialViewModel(int? cityId, string name, DateTime? availableFrom, int? numberOfBeds, string sortType, string sortDirection)
        {
            if (availableFrom == DateTime.MinValue)
                availableFrom = null;
            apartmentsViewModel.Apartments = apartmentService.SearchApartments(cityId.GetValueOrDefault(), name, availableFrom, numberOfBeds, sortType, sortDirection)
                 .Select(x => new ApartmentModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Price = x.Price,
                     AvailableFrom = x.AvailableFrom,
                     NumberOfBeds = x.NumberOfBeds,
                     AverageRating = float.Parse(x.AverageRating.ToString("0.00"))
                 }).ToList();
            return apartmentsViewModel;    
        }

        [HttpGet]
        [Route("home/getapartmentsbysearch")]
        public IActionResult GetApartmentsBySearch([FromQuery]int cityId, [FromQuery]string name, [FromQuery]DateTime availableFrom, [FromQuery]int numberOfBeds, string sortType, string sortDirection)
        {
            var model = this.GetFullAndPartialViewModel(cityId, name, availableFrom, numberOfBeds, sortType, sortDirection);
            return PartialView("_ListApartments", model);
        }

        [HttpPost]
        [Route("home/addrating")]
        public decimal AddRating(int apartmentId, int ratingValue)
        {
            
            var aptId = apartmentId;
            var ratVal = ratingValue;
            var avgRatingNow = ratingService.AddRating(ratVal, aptId);
            return (decimal)avgRatingNow;
            
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
