using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;

namespace DigiMediaStore.BusinessLogic.Services;

public class UserService : IUserService
{
    private IRepositoryWrapper _repositoryWrapper;

    public UserService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _repositoryWrapper.User.FindAll();
        return users.ToList();
    }

    public async Task<User> GetById(int id)
    {
        var users = await _repositoryWrapper.User.FindByCondition(x => x.UserId == id);
        return users.First();
    }

    public async Task Create(User model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));
        if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.PasswordHash) || string.IsNullOrWhiteSpace(model.FullName))
            throw new ArgumentException("User fields Email, PasswordHash and FullName are required");
        await _repositoryWrapper.User.Create(model);
        await _repositoryWrapper.Save();
    }

    public async Task Update(User model)
    {
        await _repositoryWrapper.User.Update(model);
        await _repositoryWrapper.Save();
    }

    public async Task Delete(int id)
    {
        var users = await _repositoryWrapper.User.FindByCondition(x => x.UserId == id);
        var user = users.First();

        await _repositoryWrapper.User.Delete(user);
        await _repositoryWrapper.Save();
    }
}
