using SafariRest.Database.Models;
using SafariRest.Database.Repository;

namespace SafariRest.Services;

public class AuthenticationService(
    IRepository<Admin> adminRepository,
    IRepository<User> userRepository
)
{
    private readonly IRepository<Admin> AdminRepository = adminRepository;
    private readonly IRepository<User> UserRepository = userRepository;
}
