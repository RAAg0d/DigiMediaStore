using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class ContentTypeRepository : RepositoryBase<ContentType>
{
    public ContentTypeRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
