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
        [Route("/contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
