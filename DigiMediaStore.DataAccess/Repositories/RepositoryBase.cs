using System.Linq.Expressions;
using DigiMediaStore.DataAccess.Interfaces;
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

    public IQueryable<T> FindAll()
    {
        return RepositoryContext.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
    }

    public void Create(T entity)
    {
        RepositoryContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        RepositoryContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        RepositoryContext.Set<T>().Remove(entity);
    }
}
