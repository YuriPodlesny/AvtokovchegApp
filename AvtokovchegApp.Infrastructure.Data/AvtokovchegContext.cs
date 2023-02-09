using AvtokovchegApp.Domain;
using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data.ConfigurationsContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace AvtokovchegApp.Infrastructure.Data
{
    public class AvtokovchegContext : DbContext
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
        }

        public DbSet<ParkingSpace> ParkingSpaces { get; set; } = null!;
        public DbSet<Renter> Renters { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<HolderCar> HolderCars { get; set; } = null!;
        public DbSet<Agreement> Agreements { get; set; } = null!;
    }
}