using AvtokovchegApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace AvtokovchegApp.Infrastructure.Data
{
    public class AvtokovchegConxext : DbContext
    {
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }

    }
}