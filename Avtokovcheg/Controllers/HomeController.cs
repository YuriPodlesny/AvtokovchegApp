using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain;
using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Avtokovcheg.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkingSpaceRepository _parkingSpace;

        public HomeController(IParkingSpaceRepository parkingSpace)
        {
            _parkingSpace = parkingSpace;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticated()
        {
            return PartialView("_Authenticated");
        }

        //[Authorize]
        //[HttpGet]
        //public async Task<IActionResult> Request(int namber)
        //{

        //    var parkingSpace = await _parkingSpace.GetAsync(namber);
        //    ViewBag.parkingSpace = parkingSpace;

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Request()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}



        protected override void Dispose(bool disposing)
        {
            _parkingSpace.Dispose();
            base.Dispose(disposing);
        }
    }
}
