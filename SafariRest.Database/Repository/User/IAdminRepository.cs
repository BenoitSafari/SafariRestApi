namespace SafariRest.Database.Repository.User;

public interface IAdminRepository : IRepository<Models.Admin>
{
    public Models.Admin? GetUserByEmail(string email);
}
