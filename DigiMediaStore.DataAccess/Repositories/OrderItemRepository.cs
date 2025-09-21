using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class OrderItemRepository : RepositoryBase<OrderItem>
{
    public OrderItemRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
