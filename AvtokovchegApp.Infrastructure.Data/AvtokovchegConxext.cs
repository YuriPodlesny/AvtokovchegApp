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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>().HasData(
                CreateParkingSpace()
                ) ;
        }

        public DbSet<ParkingSpace> ParkingSpaces { get; set; } = null!;



        private ParkingSpace[] CreateParkingSpace()
        {
            int countSpace = 567;
            var parkingSpaces = new ParkingSpace[countSpace];
            for (int i = 0; i < countSpace; i++)
            {
                parkingSpaces[i] = new ParkingSpace { Id= i+1,  Namber = i+1};   
            }
            return parkingSpaces;
        } 
    }
}