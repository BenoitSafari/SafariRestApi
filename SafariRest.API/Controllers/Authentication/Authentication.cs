using Microsoft.AspNetCore.Mvc;
using SafariRest.Services;

namespace SafariRest.API.Controllers;

[ApiController]
[Route("/auth")]
public class Authentication(UserService userService) : ControllerBase
{
    private readonly UserService UserService = userService;

    [HttpPost("/admin/login")]
    public IActionResult AdminLogin() => Ok("Not implemented yet");

    [HttpPost("/user/login")]
    public IActionResult UserLogin() => Ok("Not implemented yet");
}
