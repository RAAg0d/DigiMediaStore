using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Wrapper;

public interface IRepositoryWrapper
{
    IRepositoryBase<User> User { get; }
    IRepositoryBase<Content> Content { get; }
    IRepositoryBase<Order> Order { get; }
    IRepositoryBase<ContentType> ContentType { get; }
    IRepositoryBase<Genre> Genre { get; }
    IRepositoryBase<Review> Review { get; }
    IRepositoryBase<Payment> Payment { get; }
    IRepositoryBase<OrderItem> OrderItem { get; }
    IRepositoryBase<PriceOption> PriceOption { get; }
    void Save();
}
