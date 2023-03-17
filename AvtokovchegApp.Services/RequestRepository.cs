using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data;
using AvtokovchegApp.Infrastructure.Data.Repository;
using AvtokovchegApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AvtokovchegApp.Services
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        private readonly AvtokovchegContext _db;
        public RequestRepository(AvtokovchegContext context, AvtokovchegContext db) : base(context)
        {
            _db = db;
        }

        public IQueryable<Request> GetRequestByState(RequestState state)
        {
            return _db.Requests.Where(x => x.State == state);
        }
    }
}
