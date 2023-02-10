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

        public HomeController(IParkingSpaceRepository parkingSpace)
        {
            _parkingSpace = parkingSpace;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Request(int Namber)
        {
            var parkingSpace = _parkingSpace.GetParkingSpace(Namber);
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
                HolderCar holderCar = new HolderCar
                {
                    Name = requestViewModel.Renter.Name,
                    Patronymic = requestViewModel.Holder.Patronymic,
                    Surname = requestViewModel.Holder.Surname
                };
                Car car = new Car
                {
                    CarBrand = requestViewModel.Car.CarBrand,
                    CarModel = requestViewModel.Car.CarModel,
                    Namber = requestViewModel.Car.Namber
                };
                ParkingSpace parkingSpace = await _parkingSpace.GetParkingSpace(requestViewModel.ParkingSpace);
                parkingSpace.IsFree = false;
                _parkingSpace.EditParkingSpace(parkingSpace);

            }
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
        base.Dispose(disposing);
    }
}
}