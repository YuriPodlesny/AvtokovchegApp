using Avtokovcheg.Infrastructure.Data;
using AvtokovchegApp.Domain.Core;

namespace AvtokovchegApp.Services.Interfaces
{
    public interface IRequestRepository : IBaseRepository<Request>
    {
        IQueryable<Request> GetRequestByState(RequestState state);
    }
}
