using SafariRest.Database.Context;

namespace SafariRest.Database.Repository.User;

public class UserRepository(MainContext context) : Repository<Models.User>(context), IUserRepository
{
    public Models.User? GetUserByUsername(string username) =>
        Context.Users.FirstOrDefault(u => u.Username == username);

    public Models.User? GetUserByEmail(string email) =>
        Context.Users.FirstOrDefault(u => u.Email == email);
}
