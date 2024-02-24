using SafariRest.Database.Models;
using SafariRest.Database.Repository;

namespace SafariRest.Services;

public class AdminService(IRepository<Admin> adminRepository)
{
    private readonly IRepository<Admin> AdminRepository = adminRepository;
}
