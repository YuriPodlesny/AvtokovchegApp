using Avtokovcheg.Domain.Interfaces;
using Avtokovcheg.Models;
using AvtokovchegApp.Domain;
using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Avtokovcheg.Controllers
{
    public class HomeController : Controller
    {
        IParkingSpaceRepository _parkingSpace;
        ICarRepository _car;
        IHolderCarRepository _holderCar;
        IRenterRepository _renter;
        IRequestRepository _request;

        public HomeController(
            IParkingSpaceRepository parkingSpace,
            ICarRepository car,
            IHolderCarRepository holderCar,
            IRenterRepository renter,
            IRequestRepository request)
        {
            _parkingSpace = parkingSpace;
            _car = car;
            _holderCar = holderCar;
            _renter = renter;
            _request = request;
        }

        public  IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Request(int namber)
        {
            
            var parkingSpace = await _parkingSpace.GetParkingSpace(namber);
            ViewBag.parkingSpace = parkingSpace;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Request(RequestViewModel requestViewModel)
        {
            if (ModelState.IsValid)
            {
                _renter.Create( new Renter
                {
                    Name = requestViewModel.Renter.Name,
                    Patronymic = requestViewModel.Renter.Patronymic,
                    Surname = requestViewModel.Renter.Surname,
                    PhoneNamber = requestViewModel.Renter.PhoneNamber
                });
                

                _holderCar.Create(new HolderCar
                {
                    Name = requestViewModel.Renter.Name,
                    Patronymic = requestViewModel.Holder.Patronymic,
                    Surname = requestViewModel.Holder.Surname
                });
                

                _car.Create(new Car
                {
                    CarBrand = requestViewModel.Car.CarBrand,
                    CarModel = requestViewModel.Car.CarModel,
                    Namber = requestViewModel.Car.Namber,
                    RenterId = requestViewModel.Renter.Id,
                    HolderCarId = requestViewModel.Holder.Id
                });
                
                _request.Create(new Request
                {
                    CreatedAt = DateTime.Now,
                    RenterId = requestViewModel.Renter.Id
                });
                
                _parkingSpace.UpdateFree(requestViewModel.ParkingSpaceId);

                return RedirectToAction("Index");
            }
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
            _car.Dispose();
            _holderCar.Dispose();
            _renter.Dispose();
            _request.Dispose();
            base.Dispose(disposing);
        }
    }
}