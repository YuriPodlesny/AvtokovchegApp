using AvtokovchegApp.Domain;
using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data.ConfigurationsContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AvtokovchegApp.Infrastructure.Data
{
    public class AvtokovchegContext : IdentityDbContext<User,ApplicationRole,Guid>
    {

        public AvtokovchegContext(DbContextOptions<AvtokovchegContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParkingSpaceConfiguration());
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>(b =>
            //{
            //    b.HasKey("UserId");
            //});
        }

        public DbSet<User> Users { get; set; } = null;
        public DbSet<ParkingSpace> ParkingSpaces { get; set; } = null!;
        //public DbSet<Request> Requests { get; set; } = null!;
        //public DbSet<Car> Cars { get; set; } = null!;
        //public DbSet<HolderCar> HolderCars { get; set; } = null!;
        //public DbSet<Agreement> Agreements { get; set; } = null!;
    }
}