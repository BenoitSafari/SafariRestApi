using System.Linq.Expressions;
using SafariRest.Database.Context;

namespace SafariRest.Database.Repository;

public class Repository<T>(MainContext context) : IRepository<T>
    where T : class
{
    public readonly MainContext Context = context;

    public async Task Create(T entity) => await Context.Set<T>().AddAsync(entity);

    public void Update(T entity) => Context.Update(entity);

    public void Delete(T entity) => Context.Set<T>().Remove(entity);

    public IQueryable<T> Get(Expression<Func<T, bool>> expression) =>
        Context.Set<T>().Where(expression);

    public T? GetById(int id) => Context.Set<T>().Find(id);

    public async Task SaveChangesAsync() => await Context.SaveChangesAsync();
}
