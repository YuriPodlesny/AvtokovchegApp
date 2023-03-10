using AvtokovchegApp.Domain.Core;
using AvtokovchegApp.Infrastructure.Data;
using AvtokovchegApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AvtokovchegApp.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AvtokovchegContext _db;

        public OrderRepository(AvtokovchegContext db)
        {
            _db = db;
        }

        public async Task<Order> GetOrderByСontractSpaceId(int contractSpaceId)
        {
            return await _db.Orders.FirstOrDefaultAsync(x => x.СontractSpaceId == contractSpaceId);
        }
    }
}
