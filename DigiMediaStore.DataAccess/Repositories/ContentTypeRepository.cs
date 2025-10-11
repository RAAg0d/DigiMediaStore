using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class ContentTypeRepository : RepositoryBase<ContentType>
{
    public ContentTypeRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }
}
