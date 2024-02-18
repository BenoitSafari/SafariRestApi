using System.Linq.Expressions;

namespace SafariRest.Database.Repository;

public interface IRepository
{
    public Task Create<T>(T entity)
        where T : class;
    public void Update<T>(T entity)
        where T : class;
    public void Delete<T>(T entity)
        where T : class;
    public IQueryable<T> Get<T>(Expression<Func<T, bool>> expression)
        where T : class;
    public Task<T> GetById<T>(int id)
        where T : class;
}
