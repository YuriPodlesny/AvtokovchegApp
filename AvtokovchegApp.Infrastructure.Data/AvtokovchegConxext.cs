using AvtokovchegApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;

namespace AvtokovchegApp.Infrastructure.Data
{
    public class AvtokovchegConxext : DbContext
    {

        public AvtokovchegConxext(DbContextOptions<AvtokovchegConxext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>().HasData(
                new ParkingSpace { Id = 1, Namber = 1 }
                );
        }

        public DbSet<ParkingSpace> ParkingSpaces { get; set; } = null!;

    }
}