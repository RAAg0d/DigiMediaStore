using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Order>> GetByUserId(int userId)
    {
        return await FindByCondition(x => x.UserId == userId);
    }

    public async Task<IEnumerable<Order>> GetByStatus(string status)
    {
        return await FindByCondition(x => x.Status == status);
    }

    public async Task<decimal> GetTotalRevenue()
    {
        var orders = await FindByCondition(x => x.Status == "Completed");
        return orders.Sum(x => x.TotalAmount);
    }

    public async Task<IEnumerable<Order>> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
    {
        return await FindByCondition(x => x.OrderDate >= startDate && x.OrderDate <= endDate);
    }
}
