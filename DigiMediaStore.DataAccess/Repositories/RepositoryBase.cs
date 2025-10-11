using System.Linq.Expressions;
using DigiMediaStore.Domain.Interfaces;
using DigiMediaStore.Domain.Models;
using DigiMediaStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiMediaStore.DataAccess.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected DigiMediaStoreContext RepositoryContext { get; set; }

    public RepositoryBase(DigiMediaStoreContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }

    public async Task<IQueryable<T>> FindAll()
    {
        return await Task.FromResult(RepositoryContext.Set<T>().AsNoTracking());
    }

    public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return await Task.FromResult(RepositoryContext.Set<T>().Where(expression).AsNoTracking());
    }

    public async Task Create(T entity)
    {
        RepositoryContext.Set<T>().Add(entity);
        await Task.CompletedTask;
    }

    public async Task Update(T entity)
    {
        RepositoryContext.Set<T>().Update(entity);
        await Task.CompletedTask;
    }

    public async Task Delete(T entity)
    {
        RepositoryContext.Set<T>().Remove(entity);
        await Task.CompletedTask;
    }
}
