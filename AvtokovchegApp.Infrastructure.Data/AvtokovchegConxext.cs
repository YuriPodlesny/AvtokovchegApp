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
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
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
                if (i <= 81 + 1)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 1 };
                if (i > 81 + 1 && i <= 162 + 1)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 2 };
                if (i > 162 + 1 && i <= 243 + 1)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 3 };
                if (i > 243 + 1 && i <= 243 + 1)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 4 };
                if (i > 162 + 1 && i <= 324 + 1)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 5 };
                if (i > 324 + 1 && i <= 405 + 1)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 6 };
                if (i > 405 + 1 && i <= 486 + 1)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 7 };
                if (i > 486 + 1 && i <= 567 + 1)
                    parkingSpaces[i] = new ParkingSpace { Namber = i + 1, Floor = 8 };
            }
            return parkingSpaces;
        }
    }
}