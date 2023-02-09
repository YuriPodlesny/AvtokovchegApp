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
    public class RequestConfigurations : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasOne(u => u.Renter)
                .WithMany(c => c.Requests)
                .HasForeignKey(u => u.RenterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
