using DigiMediaStore.Domain.Models;

namespace DigiMediaStore.Domain.Interfaces;

public interface IOrderRepository : IRepositoryBase<Order>
{
    Task<IEnumerable<Order>> GetByUserId(int userId);
    Task<IEnumerable<Order>> GetByStatus(string status);
    Task<decimal> GetTotalRevenue();
    Task<IEnumerable<Order>> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
}
