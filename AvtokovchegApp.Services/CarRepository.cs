using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data;
using AvtokovchegApp.Infrastructure.Data.Repository;
using AvtokovchegApp.Services.Interfaces;

namespace AvtokovchegApp.Services
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
            return _db.Cars.Where(x => x.СontractSpaceId == contractSpaceId);
        }
    }
}
