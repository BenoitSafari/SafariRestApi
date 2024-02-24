namespace SafariRest.Database.Repository.User;

public interface IUserRepository : IRepository<Models.User>
{
    public Models.User? GetUserByUsername(string username);
    public Models.User? GetUserByEmail(string email);
}
