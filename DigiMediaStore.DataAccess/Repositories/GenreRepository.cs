using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class GenreRepository : RepositoryBase<Genre>
{
    public GenreRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
