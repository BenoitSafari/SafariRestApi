using System.Linq.Expressions;
using SafariRest.Database.Context;

namespace SafariRest.Database.Repository;

public interface IRepository<T>
    where T : class
{
    public Task Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public IQueryable<T> Get(Expression<Func<T, bool>> expression);
    public T? GetById(int id);
    public Task SaveChangesAsync();
}
