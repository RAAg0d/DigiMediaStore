using DigiMediaStore.Domain.Models;

namespace DigiMediaStore.Domain.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User?> GetByEmail(string email);
    Task<bool> EmailExists(string email);
    Task<IEnumerable<User>> GetActiveUsers();
}
