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
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly AvtokovchegContext _db;
        public CarRepository(AvtokovchegContext context, AvtokovchegContext db) : base(context)
        {
            _db = db;
        }

        public IQueryable<Car> GetCarByContractSpaceId(int contractSpaceId)
        {
            return _db.Cars.Where(x=> x.СontractSpaceId == contractSpaceId);
        }
    }
}
