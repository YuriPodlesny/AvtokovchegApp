using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        public IActionResult Index()
        {
            return View(_carRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
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
                    UserId = model.UserId
                };
                var result = await _carRepository.Create(car);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        

    }
}
