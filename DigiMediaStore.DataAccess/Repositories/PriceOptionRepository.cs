using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class PriceOptionRepository : RepositoryBase<PriceOption>
{
    public PriceOptionRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
