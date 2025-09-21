using DigiMediaStore.DataAccess.Interfaces;
using DigiMediaStore.DataAccess.Models;

namespace DigiMediaStore.DataAccess.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DigiMediaStoreContext repositoryContext) : base(repositoryContext)
    {
    }

    public User? GetByEmail(string email)
    {
        return FindByCondition(x => x.Email == email).FirstOrDefault();
    }

    public bool EmailExists(string email)
    {
        return FindByCondition(x => x.Email == email).Any();
    }

    public IEnumerable<User> GetActiveUsers()
    {
        return FindByCondition(x => x.IsActive == true);
    }
}
