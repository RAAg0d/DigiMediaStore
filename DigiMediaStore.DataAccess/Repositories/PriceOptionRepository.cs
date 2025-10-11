using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class PriceOptionRepository : RepositoryBase<PriceOption>
{
    public PriceOptionRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
