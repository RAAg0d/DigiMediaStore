using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class ContentRepository : RepositoryBase<Content>, IContentRepository
{
    public ContentRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Content>> GetByType(int typeId)
    {
        return await FindByCondition(x => x.TypeId == typeId);
    }

    public async Task<IEnumerable<Content>> GetByGenre(int genreId)
    {
        return await FindByCondition(x => x.Genres.Any(g => g.GenreId == genreId));
    }

    public async Task<IEnumerable<Content>> Search(string searchTerm)
    {
        return await FindByCondition(x => x.Title.Contains(searchTerm) ||
                                   (x.Description != null && x.Description.Contains(searchTerm)));
    }

    public async Task<IEnumerable<Content>> GetAvailableContent()
    {
        return await FindByCondition(x => x.IsAvailable == true);
    }

    public async Task<IEnumerable<Content>> GetByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return await FindByCondition(x => x.BasePrice >= minPrice && x.BasePrice <= maxPrice);
    }
}
