using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class PaymentRepository : RepositoryBase<Payment>
{
    public PaymentRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
