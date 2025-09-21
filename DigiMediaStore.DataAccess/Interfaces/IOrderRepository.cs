using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Interfaces;

public interface IOrderRepository : IRepositoryBase<Order>
{
    IEnumerable<Order> GetByUserId(int userId);
    IEnumerable<Order> GetByStatus(string status);
    decimal GetTotalRevenue();
    IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
}
