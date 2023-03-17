using Avtokovcheg.Infrastructure.Data;
using AvtokovchegApp.Domain.Core;

namespace AvtokovchegApp.Services.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        IQueryable<Car> GetCarByContractSpaceId(int contractSpaceId);

    }
}
