using Microsoft.AspNetCore.Mvc;

namespace SafariRest.API.Controllers;

[ApiController]
[Route("/")]
public class RootController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult GetApiState()
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        var version = assembly.GetName().Version;
        var name = assembly.GetName().Name;
        return Ok(new { name, version });
    }
}
