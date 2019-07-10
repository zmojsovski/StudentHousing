using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentHousing.Models;
using DataAccess.Models;
using Services.Services;

namespace StudentHousing.Controllers
{
    public class HomeController : Controller
    {
        ApartmentService apartmentService = new ApartmentService();
        RatingService ratingService = new RatingService();
        
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [Route("/about")]
        public IActionResult About([FromBody]Apartment model)
        {
            if (ModelState.IsValid)
            {
                var flag = apartmentService.CreateApartment(model);
                return Ok(flag);
            }
            ViewData["Message"] = "Your application description page.";
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
            IEnumerable<Apartment> apartments = apartmentService.GetApartmentsbyCity(id);
            if (apartments != null)
            {
                return Ok(apartments);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
