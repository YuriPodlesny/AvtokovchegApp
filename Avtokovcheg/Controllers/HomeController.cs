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
        private readonly ICarRepository _car;
        private readonly IHolderCarRepository _holderCar;
        private readonly IUserRepository _user;
        private readonly IRequestRepository _request;

        public HomeController(
            IParkingSpaceRepository parkingSpace,
            ICarRepository car,
            IHolderCarRepository holderCar,
            IUserRepository user,
            IRequestRepository request)
        {
            _parkingSpace = parkingSpace;
            _car = car;
            _holderCar = holderCar;
            _user = user;
            _request = request;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticated()
        {
            return PartialView("_Authenticated");
        }



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Request(int namber)
        {

            var parkingSpace = await _parkingSpace.GetAsync(namber);
            ViewBag.parkingSpace = parkingSpace;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Request()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        protected override void Dispose(bool disposing)
        {
            _parkingSpace.Dispose();
            _car.Dispose();
            _holderCar.Dispose();
            _request.Dispose();
            base.Dispose(disposing);
        }
    }
}
