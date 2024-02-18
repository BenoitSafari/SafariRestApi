using System.Linq.Expressions;
using SafariRest.Database.Context;

namespace SafariRest.Database.Repository;

public class Repository(MainContext context) : IRepository
{
    private readonly MainContext Context = context;

    public async Task Create<T>(T entity)
        where T : class => await Context.Set<T>().AddAsync(entity);

    public void Update<T>(T entity)
        where T : class => Context.Update(entity);

    public void Delete<T>(T entity)
        where T : class => Context.Set<T>().Remove(entity);

    public IQueryable<T> Get<T>(Expression<Func<T, bool>> expression)
        where T : class => Context.Set<T>().Where(expression);

    public Task<T> GetById<T>(int id)
        where T : class => throw new NotImplementedException();
}
