﻿using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Models;
using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Controllers
{
    [Authorize(Roles ="admin")]
    public class СontractSpaceController : Controller
    {
        private readonly IСontractSpaceRepository _сontractSpace;
        private readonly IParkingSpaceRepository _parkingSpace;
        private readonly UserManager<User> _userManager;
        public СontractSpaceController(IСontractSpaceRepository сontractSpace, UserManager<User> userManager, IParkingSpaceRepository parkingSpace)
        {
            _сontractSpace = сontractSpace;
            _userManager = userManager;
            _parkingSpace = parkingSpace;
        }

        public IActionResult Index()
        {
            return View(_сontractSpace.GetAll());
        }

        [HttpGet]
        public IActionResult Create(string userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateСontractSpaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parkingSpace = await _parkingSpace.Get(model.NamberSpace);
                if (parkingSpace == null)
                {
                    return NotFound();
                }
                if (parkingSpace.IsFree)
                {
                    СontractSpace сontract = new СontractSpace
                    {
                        DateStart = model.DateStart,
                        Time = model.Time,
                        NamberContract = model.NamberContract,
                        NamberSpace = model.NamberSpace,
                        UserId = model.UserId,
                        Cost = model.Cost,
                    };

                    var result = await _сontractSpace.Create(сontract);
                    if (result == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int contractId)
        {
            var car = await _сontractSpace.Get(contractId);
            if (car == null)
            {
                return NotFound();
            }
            var contract = new EditСontractSpaceViewModel
            {
                Id = contractId,
                DateStart = car.DateStart,
                Time = car.Time,
                NamberContract = car.NamberContract,
                NamberSpace = car.NamberSpace,
                Cost = car.Cost,
                UserId = car.UserId,
            };
            return View(contract);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditСontractSpaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var сontractSpace = await _сontractSpace.Get(model.Id);
                if (сontractSpace != null)
                {
                    сontractSpace.Id = model.Id;
                    сontractSpace.DateStart = model.DateStart;
                    сontractSpace.Time = model.Time;
                    сontractSpace.NamberContract = model.NamberContract;
                    сontractSpace.NamberSpace = model.NamberSpace;
                    сontractSpace.Cost = model.Cost;
                    сontractSpace.UserId = model.UserId;

                    var result = await _сontractSpace.Update(сontractSpace);
                    if (result == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int contractId)
        {
            var contract = await _сontractSpace.Get(contractId);
            var user = await _userManager.FindByIdAsync(contract.UserId);
            if (contract == null || user == null)
            {
                return NotFound();
            }
            var model = new DetailСontractSpaceViewModel
            {
                DateStart = contract.DateStart,
                DateEnd = contract.DateEnd,
                Time = contract.Time,
                NamberContract = contract.NamberContract,
                NamberSpace = contract.NamberSpace,
                Cost = contract.Cost,
                UserName = user.UserName,
                UserSurname = user.Surname,
                UserPatronymic = user.Patronymic,
                UserPhoneNamber = user.PhoneNumber,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int contractId)
        {
            var car = _сontractSpace.Get(contractId);
            if (car != null)
            {
                var result = await _сontractSpace.Delete(contractId);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
