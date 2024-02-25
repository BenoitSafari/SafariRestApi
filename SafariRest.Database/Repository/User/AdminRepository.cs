using SafariRest.Database.Context;

namespace SafariRest.Database.Repository.User;

public class AdminRepository(MainContext context)
    : Repository<Models.Admin>(context),
        IAdminRepository
{
    public Models.Admin? GetUserByEmail(string email) =>
        Context.Admins.FirstOrDefault(u => u.Email == email);
}
