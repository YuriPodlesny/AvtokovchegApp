using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain;
using AvtokovchegApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Avtokovcheg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("AvtokovchegDatabase");
            builder.Services.AddDbContext<AvtokovchegConxext>(options => options.UseNpgsql(connection));

            builder.Services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            //app.MapGet("/", (AvtokovchegConxext db) => db.ParkingSpaces.ToList());

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}