using AvtokovchegApp.Domain;
using AvtokovchegApp.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Infrastructure.Data.ConfigurationsContext
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasOne(u => u.Renter)
                .WithMany(c => c.Cars)
                .HasForeignKey(u => u.RenterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.HolderCar)
                .WithMany(c => c.Cars)
                .HasForeignKey(u => u.HolderCarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
