using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class OrderItemRepository : RepositoryBase<OrderItem>
{
    public OrderItemRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
