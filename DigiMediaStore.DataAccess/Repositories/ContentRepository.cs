using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class ContentRepository : RepositoryBase<Content>, IContentRepository
{
    public ContentRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Content> GetByType(int typeId)
    {
        return FindByCondition(x => x.TypeId == typeId);
    }

    public IEnumerable<Content> GetByGenre(int genreId)
    {
        return FindByCondition(x => x.Genres.Any(g => g.GenreId == genreId));
    }

    public IEnumerable<Content> Search(string searchTerm)
    {
        return FindByCondition(x => x.Title.Contains(searchTerm) || 
                                   (x.Description != null && x.Description.Contains(searchTerm)));
    }

    public IEnumerable<Content> GetAvailableContent()
    {
        return FindByCondition(x => x.IsAvailable == true);
    }

    public IEnumerable<Content> GetByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return FindByCondition(x => x.BasePrice >= minPrice && x.BasePrice <= maxPrice);
    }
}
