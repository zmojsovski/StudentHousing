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

namespace StudentHousing.Controllers
{
    public class HomeController : Controller
    {
        IApartmentService apartmentService = new ApartmentService();
        IRatingService ratingService = new RatingService();
        ICityService cityService = new CityService();
        ApartmentsViewModel apartmentsViewModel = new ApartmentsViewModel();
        RatingsViewModel ratingsViewModel = new RatingsViewModel();
        
        [HttpGet]
        public IActionResult Index()
        {
            var allCities = cityService.GetAll();
            apartmentsViewModel.Cities = allCities.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            var model = this.GetFullAndPartialViewModel(allCities.FirstOrDefault().Id, null, null, null, 0, 0);
            return this.View(model);
        }

        private ApartmentsViewModel GetFullAndPartialViewModel(int? cityId, string name, DateTime? availableFrom, int? numberOfBeds, int flagPrice, int flagRating)
        {
            var apartments = apartmentService.SearchApartments(cityId.GetValueOrDefault(), name, availableFrom, numberOfBeds);
            apartmentsViewModel.Apartments = apartments.Select(x => new ApartmentModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                AvailableFrom = x.AvailableFrom,
                NumberOfBeds = x.NumberOfBeds,
                AverageRating = float.Parse(apartmentService.GetaverageRatingbyId(x.Id).ToString("0.00"))
            }).ToList();

            if (flagPrice > flagRating)
            {
                if (flagPrice != 0 && flagPrice % 2 == 1)
                    apartmentsViewModel.Apartments.Sort((x1, x2) => x2.Price.CompareTo(x1.Price));
                else if (flagPrice != 0 && flagPrice % 2 == 0)
                    apartmentsViewModel.Apartments.Sort((x1, x2) => x1.Price.CompareTo(x2.Price));
            }
            else if(flagRating > flagPrice)
            {
                if (flagRating != 0 && flagRating % 2 == 1)
                    apartmentsViewModel.Apartments.Sort((x1, x2) => x2.AverageRating.CompareTo(x1.AverageRating));
                else if (flagRating != 0 && flagRating % 2 == 0)
                    apartmentsViewModel.Apartments.Sort((x1, x2) => x1.AverageRating.CompareTo(x2.AverageRating));
            }
            return apartmentsViewModel;    
        }

        [HttpGet]
        [Route("home/getapartmentsbysearch")]
        public IActionResult GetApartmentsBySearch([FromQuery]int cityId, [FromQuery]string name, [FromQuery]DateTime availableFrom, [FromQuery]int numberOfBeds, int flagPrice, int flagRating)
        {
            var model = this.GetFullAndPartialViewModel(cityId, name, availableFrom, numberOfBeds, flagPrice, flagRating);
            return PartialView("_ListApartments", model);

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
        public decimal AddRating(int apartmentId, int ratingValue)
        {
            
            var aptId = apartmentId;
            var ratVal = ratingValue;
            var avgRatingNow = ratingService.AddRating(ratVal, aptId);
            //ViewData["avgRating"] = avgRatingNow.ToString();
            //ViewBag.MyRating = avgRatingNow.ToString();
            //apartmentService.GetAll().FirstOrDefault(x => x.Id == aptId).AverageRating = avgRatingNow;




            //apartmentsViewModel.Apartments.FirstOrDefault(x => x.Id == aptId).AverageRating = avgRatingNow;
            //RatingModel ratingModel = new RatingModel()
            //{
            //    AverageRating = avgRatingNow
            //};
            //return PartialView("_RatingSection", apartmentsViewModel);
            return (decimal)avgRatingNow;
            
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
