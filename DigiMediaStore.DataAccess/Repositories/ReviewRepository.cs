using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class ReviewRepository : RepositoryBase<Review>
{
    public ReviewRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
