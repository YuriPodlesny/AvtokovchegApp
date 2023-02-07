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
            modelBuilder.Entity<ParkingSpace>().HasData(CreateParkingSpace());
            modelBuilder.Entity<ParkingSpace>().HasKey(p => p.Namber);
        }

        public DbSet<ParkingSpace> ParkingSpaces { get; set; } = null!;



        private ParkingSpace[] CreateParkingSpace()
        {
            int countSpace = 567;
            var parkingSpaces = new ParkingSpace[countSpace];
            for (int i = 0; i < countSpace; i++)
            {
                if (i < 81)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 2 };
                if (i >= 81 && i < 162)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 3 };
                if (i >= 162 && i < 243)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 4 };
                if (i >= 243 && i < 324)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 5 };
                if (i >= 324 && i < 405)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 6 };
                if (i >= 405 && i < 486)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 7 };
                if (i >= 486 && i < 567)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 8 };
            }
            return parkingSpaces;
        }
    }
}