using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Interfaces;

public interface IContentRepository : IRepositoryBase<Content>
{
    IEnumerable<Content> GetByType(int typeId);
    IEnumerable<Content> GetByGenre(int genreId);
    IEnumerable<Content> Search(string searchTerm);
    IEnumerable<Content> GetAvailableContent();
    IEnumerable<Content> GetByPriceRange(decimal minPrice, decimal maxPrice);
}
