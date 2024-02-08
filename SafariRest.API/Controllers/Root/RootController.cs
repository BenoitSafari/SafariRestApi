using Microsoft.AspNetCore.Mvc;

namespace SafariRest.API.Controllers;

[ApiController]
[Route("/")]
public class RootController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Get() => Ok("Pong");
}
