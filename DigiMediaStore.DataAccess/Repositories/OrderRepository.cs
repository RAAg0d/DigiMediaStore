using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Order> GetByUserId(int userId)
    {
        return FindByCondition(x => x.UserId == userId);
    }

    public IEnumerable<Order> GetByStatus(string status)
    {
        return FindByCondition(x => x.Status == status);
    }

    public decimal GetTotalRevenue()
    {
        return FindByCondition(x => x.Status == "Completed").Sum(x => x.TotalAmount);
    }

    public IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
    {
        return FindByCondition(x => x.OrderDate >= startDate && x.OrderDate <= endDate);
    }
}
