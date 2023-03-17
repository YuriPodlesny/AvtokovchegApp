using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        protected override void Dispose(bool disposing)
        {
            _parkingSpace.Dispose();
            base.Dispose(disposing);
        }
    }
}
