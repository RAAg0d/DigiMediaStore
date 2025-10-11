using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class PaymentRepository : RepositoryBase<Payment>
{
    public PaymentRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
