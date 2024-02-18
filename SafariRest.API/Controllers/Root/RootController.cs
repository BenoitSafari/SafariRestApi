using Microsoft.AspNetCore.Mvc;

namespace SafariRest.API.Controllers;

[ApiController]
[Route("/")]
public class RootController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get() => Ok("Pong");
}
