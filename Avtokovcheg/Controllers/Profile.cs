using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Controllers
{
    public class Profile : Controller
    {
        private readonly UserManager<User> _userManager;

        public Profile(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
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
                View(profile);
            }
            return NotFound();
        }
    }
}
