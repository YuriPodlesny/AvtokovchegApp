using Avtokovcheg.Domain.Interfaces;
using Avtokovcheg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Avtokovcheg.Controllers
{
    public class HomeController : Controller
    {
        IParkingSpaceRepository _parkingSpace;

        public HomeController(IParkingSpaceRepository parkingSpace)
        {
            _parkingSpace = parkingSpace;
        }

        public IActionResult Index()
        {
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

        protected override void Dispose(bool disposing)
        {
            _parkingSpace.Dispose();
            base.Dispose(disposing);
        }
    }
}