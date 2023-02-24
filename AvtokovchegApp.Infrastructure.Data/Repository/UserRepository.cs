using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserRepository(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public async Task<IdentityResult> Create(User entety, string password)
        {
            return await _userManager.CreateAsync(entety, password);
            
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<SignInResult> SetCookies(string name, string password)
        {
            var user = await _userManager.FindByEmailAsync(name);
            return await _signInManager.PasswordSignInAsync(user, password, false, false);
        }

        public async void SingOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async void SingInAsync(User user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, false);
        }






    }
}
