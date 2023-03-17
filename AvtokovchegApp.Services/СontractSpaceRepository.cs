using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data;
using AvtokovchegApp.Infrastructure.Data.Repository;
using AvtokovchegApp.Services.Interfaces;

namespace AvtokovchegApp.Services
{
    public class СontractSpaceRepository : BaseRepository<СontractSpace>, IСontractSpaceRepository
    {
        private readonly AvtokovchegContext _db;
        public СontractSpaceRepository(AvtokovchegContext context, AvtokovchegContext db) : base(context)
        {
            _db = db;
        }

        public IEnumerable<СontractSpace> GetContractByUserId(string userId)
        {
            return _db.ContractSpaces.Where(x => x.UserId == userId);
        }

    }
}
