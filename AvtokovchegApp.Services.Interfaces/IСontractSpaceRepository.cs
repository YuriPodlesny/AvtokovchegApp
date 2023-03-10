using Avtokovcheg.Infrastructure.Data;
using AvtokovchegApp.Domain.Core;

namespace AvtokovchegApp.Services.Interfaces
{
    public interface IСontractSpaceRepository : IBaseRepository<СontractSpace>
    {
        IEnumerable<СontractSpace> GetContractByUserId(string userId);
    }
}
