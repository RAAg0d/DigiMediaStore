using DigiMediaStore.Domain.Models;

namespace DigiMediaStore.Domain.Interfaces;

public interface IContentRepository : IRepositoryBase<Content>
{
    Task<IEnumerable<Content>> GetByType(int typeId);
    Task<IEnumerable<Content>> GetByGenre(int genreId);
    Task<IEnumerable<Content>> Search(string searchTerm);
    Task<IEnumerable<Content>> GetAvailableContent();
    Task<IEnumerable<Content>> GetByPriceRange(decimal minPrice, decimal maxPrice);
}
