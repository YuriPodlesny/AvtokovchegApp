using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AvtokovchegApp.Infrastructure.Data.Repository
{
    public class HolderCarRepository : BaseRepository<HolderCar>, IHolderCarRepository
    {
        public HolderCarRepository(AvtokovchegContext context) : base(context)
        {
        }
    }
}
