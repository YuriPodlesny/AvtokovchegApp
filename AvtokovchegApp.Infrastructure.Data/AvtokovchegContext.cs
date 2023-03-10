using AvtokovchegApp.Domain;
using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data.ConfigurationsContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AvtokovchegApp.Infrastructure.Data
{
    public class AvtokovchegContext : IdentityDbContext<User>
    {
        public DbSet<ParkingSpace> ParkingSpaces { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<СontractSpace> ContractSpaces { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null;


        public AvtokovchegContext(DbContextOptions<AvtokovchegContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParkingSpaceConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}