using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Models;
using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Controllers
{
    [Authorize]
    public class Profile : Controller
    {
        private readonly UserManager<User> _userManager;

        public Profile(UserManager<User> userManager, IСontractSpaceRepository сontractSpace)
        {
            _userManager = userManager;
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
    }
}
