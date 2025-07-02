using Microsoft.AspNetCore.Mvc;

namespace PresenceLoggingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecurityCheckpoint : Controller
{
    
    [HttpGet]
    public IActionResult Index()
    {
        throw new NotImplementedException();
    }
}