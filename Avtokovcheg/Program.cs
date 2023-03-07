using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain;
using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data;
using AvtokovchegApp.Infrastructure.Data.DbInitializer;
using AvtokovchegApp.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Avtokovcheg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connection = builder.Configuration.GetConnectionString("AvtokovchegDatabase");
            builder.Services.AddDbContext<AvtokovchegContext>(options =>
            {
                options.UseNpgsql(connection);
            })
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<AvtokovchegContext>();

            builder.Services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IÑontractSpaceRepository, ÑontractSpaceRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRequestRepository, RequestRepository>();
            builder.Services.AddScoped<IDbInitializer, RoleInitializer>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Admin/login";
                options.AccessDeniedPath = "/Home/AccessDenied";
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            SeedDatabase();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            void SeedDatabase()
            {
                using (var scrope = app.Services.CreateScope())
                {
                    var dbInitializer = scrope.ServiceProvider.GetRequiredService<IDbInitializer>();
                    dbInitializer.Initialize();
                }
            }
        }
    }
}