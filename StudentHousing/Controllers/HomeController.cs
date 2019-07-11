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

namespace StudentHousing.Controllers
{
    public class HomeController : Controller
    {
        IApartmentService apartmentService = new ApartmentService();
        IRatingService ratingService = new RatingService();
        
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
              //  return Json(new {Success = true, Message= "Apartment was succesfully created."});
            }
            return View();
        }
        [HttpGet]
        [Route("/about")]
        public IActionResult About()
        {

           
            ViewData["Title"] = "Create Apartment";
            return View();
        }
        [HttpPost]
        [Route("/contact")]
        public IActionResult Contact([FromBody]Rating model)
        {
            if (ModelState.IsValid)
            {
                var flag = ratingService.SendRating(model);
                return Ok(flag);
            }
            ViewData["Message"] = "";

            return View();
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
