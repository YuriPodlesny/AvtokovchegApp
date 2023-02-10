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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Request(int namber)
        {
            var parkingSpace = _parkingSpace.GetParkingSpace(namber);
            return View(parkingSpace);
        }

        [HttpPost]
        public async void Request(RequestViewModel requestViewModel)
        {
            if (ModelState.IsValid)
            {
                Renter renter = new Renter
                {
                    Name = requestViewModel.Renter.Name,
                    Patronymic = requestViewModel.Renter.Patronymic,
                    Surname = requestViewModel.Renter.Surname,
                    PhoneNamber = requestViewModel.Renter.PhoneNamber
                };
                _renter.Create(renter);

                HolderCar holderCar = new HolderCar
                {
                    Name = requestViewModel.Renter.Name,
                    Patronymic = requestViewModel.Holder.Patronymic,
                    Surname = requestViewModel.Holder.Surname
                };
                _holderCar.Create(holderCar);

                Car car = new Car
                {
                    CarBrand = requestViewModel.Car.CarBrand,
                    CarModel = requestViewModel.Car.CarModel,
                    Namber = requestViewModel.Car.Namber
                };
                _car.Create(car);

                Request request = new Request
                {
                    CreatedAt = DateTime.Now,
                };
                _request.Create(request);

                ParkingSpace parkingSpace = await _parkingSpace.GetParkingSpace(requestViewModel.ParkingSpace);
                parkingSpace.IsFree = false;
                _parkingSpace.EditParkingSpace(parkingSpace);

            }
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