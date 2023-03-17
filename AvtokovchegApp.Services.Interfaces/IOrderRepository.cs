using AvtokovchegApp.Domain.Core;

namespace AvtokovchegApp.Services.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByСontractSpaceId(int contractSpaceId);
    }
}
