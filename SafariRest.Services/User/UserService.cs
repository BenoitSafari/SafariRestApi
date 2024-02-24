using SafariRest.Database.Models;
using SafariRest.Database.Repository;

namespace SafariRest.Services;

public class UserService(IRepository<User> userRepository)
{
    private readonly IRepository<User> UserRepository = userRepository;
}
