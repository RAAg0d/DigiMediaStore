using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<User?> GetByEmail(string email)
    {
        var users = await FindByCondition(x => x.Email == email);
        return users.FirstOrDefault();
    }

    public async Task<bool> EmailExists(string email)
    {
        var users = await FindByCondition(x => x.Email == email);
        return users.Any();
    }

    public async Task<IEnumerable<User>> GetActiveUsers()
    {
        return await FindByCondition(x => x.IsActive == true);
    }
}
