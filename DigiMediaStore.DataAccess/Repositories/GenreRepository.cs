using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class GenreRepository : RepositoryBase<Genre>
{
    public GenreRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
