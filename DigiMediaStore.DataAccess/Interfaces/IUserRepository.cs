using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    User? GetByEmail(string email);
    bool EmailExists(string email);
    IEnumerable<User> GetActiveUsers();
}
