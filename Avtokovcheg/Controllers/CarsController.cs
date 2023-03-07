using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IСontractSpaceRepository _сontractSpace;
        private readonly UserManager<User> _userManager;

        public CarsController(ICarRepository carRepository, UserManager<User> userManager, IСontractSpaceRepository сontractSpace)
        {
            _carRepository = carRepository;
            _userManager = userManager;
            _сontractSpace = сontractSpace;
        }


        public IActionResult Index()
        {
            return View(_carRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create(string contractId)
        {
            ViewBag.ContractId = contractId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car
                {
                    CarModel = model.CarBrand,
                    CarBrand = model.CarBrand,
                    Namber = model.Namber,
                    HolderName = model.HolderName,
                    HolderPatronymic = model.HolderPatronymic,
                    HolderSurname = model.HolderSurname,
                    СontractSpaceId = model.СontractSpaceId,
                };
                var result = await _carRepository.Create(car);
                if (result == true)
                {
                    return RedirectToAction("Index", "Users");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int carId)
        {
            Car? car = await _carRepository.Get(carId);
            if (car == null)
            {
                return NotFound();
            }
            var model = new EditCarViewModel
            {
                Id = car.Id,
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                HolderName = car.HolderName,
                HolderPatronymic = car.HolderPatronymic,
                HolderSurname = car.HolderSurname,
                Namber = car.Namber
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                Car? car = await _carRepository.Get(model.Id);
                if (car != null)
                {
                    car.CarBrand = model.CarBrand;
                    car.CarModel = model.CarModel;
                    car.Namber = model.Namber;
                    car.HolderName = model.HolderName;
                    car.HolderSurname = model.HolderSurname;
                    car.HolderPatronymic = model.HolderPatronymic;

                    var result = await _carRepository.Update(car);
                    if (result == true)
                    {
                        return RedirectToAction("Index", "Cars");
                    }
                }
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int carId)
        {
            Car? car = await _carRepository.Get(carId);
            if (car == null)
            {
                return NotFound();
            }
            var model = new DetailCarViewModel
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                Namber = car.Namber,
                HolderName = car.HolderName,
                HolderPatronymic = car.HolderPatronymic,
                HolderSurname = car.HolderSurname,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int carId)
        {
            var car = _carRepository.Get(carId);
            if (car != null)
            {
                var result = await _carRepository.Delete(carId);
                if(result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

    }
}
