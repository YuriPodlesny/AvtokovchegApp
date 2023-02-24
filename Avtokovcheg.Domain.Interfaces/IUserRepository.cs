using AvtokovchegApp.Domain.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtokovcheg.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByName(string name);
        Task<SignInResult> SetCookies(string name, string password);
        void SingOutAsync();
        void SingInAsync(User user, bool isPersistent);
        Task<IdentityResult> Create(User entety, string password);
    }
}
