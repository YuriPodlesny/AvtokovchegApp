using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Models;
using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AvtokovchegApp.Controllers
{
    [Authorize]
    public class Profile : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IRequestRepository _requestRepository;

        public Profile(UserManager<User> userManager, IСontractSpaceRepository сontractSpace, IRequestRepository requestRepository)
        {
            _userManager = userManager;
            _requestRepository = requestRepository;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    var profile = new ProfileUserViewModel
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        PhoneNamber = user.PhoneNumber,
                        Name = user.Name,
                        Surname = user.Surname,
                        Patronymic = user.Patronymic,
                    };
                    return View(profile);
                }
                return NotFound();
            }
            return RedirectToAction("Account/Login");
        }

        [HttpGet]
        public async Task<IActionResult> CreateRequest(int namber)
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    var request = new CreateRequestViewModel
                    {
                        UserId = user.Id,
                        NamberSpace = namber
                    };
                    return View(request);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                Request request = new Request
                {
                    NamberSpace = model.NamberSpace,
                    UserId = model.UserId
                };
                var result = await _requestRepository.Create(request);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
    }
}
