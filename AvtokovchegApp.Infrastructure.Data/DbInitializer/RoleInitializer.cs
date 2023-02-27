using AvtokovchegApp.Domain.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Infrastructure.Data.DbInitializer
{
    public class RoleInitializer : IDbInitializer
    {
        private readonly AvtokovchegContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleInitializer(AvtokovchegContext db, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            string adminPhoneNamber = "+7987654321";
            string adminPassword = "123456";
            string adminRole = "admin";

            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
            }

            if (! _roleManager.RoleExistsAsync(adminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(adminRole)).GetAwaiter().GetResult();
                _userManager.CreateAsync(new User
                {
                    UserName = adminPhoneNamber,
                    Name = adminRole,
                    PhoneNumber = adminPhoneNamber,
                    Patronymic = adminRole,
                    Surname = adminRole,
                }, adminPassword).GetAwaiter().GetResult();
                
                User user = _db.Users.FirstOrDefault(u=>u.PhoneNumber == adminPhoneNamber);
                _userManager.AddToRoleAsync(user, adminRole).GetAwaiter().GetResult();
            }
        }
    }
}
