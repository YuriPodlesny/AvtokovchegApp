using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data;
using AvtokovchegApp.Infrastructure.Data.Repository;
using AvtokovchegApp.Services.Interfaces;

namespace AvtokovchegApp.Services
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(AvtokovchegContext context) : base(context)
        {
        }
    }
}
