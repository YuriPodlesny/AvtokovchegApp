using AvtokovchegApp.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Infrastructure.Data.ConfigurationsContext
{
    public class ParkingSpaceConfiguration : IEntityTypeConfiguration<ParkingSpace>
    {
        public void Configure(EntityTypeBuilder<ParkingSpace> builder)
        {
            builder.HasData(CreateParkingSpace());
            builder.HasKey(p => p.Namber);

            
        }
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
