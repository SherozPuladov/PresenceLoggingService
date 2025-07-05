using Microsoft.AspNetCore.Mvc;

namespace PresenceLoggingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecurityCheckpoint : Controller
{
    [HttpPost("start-shift/{employee-id:int}")]
    public ActionResult<string> StartShift(int employeeId)
    {
        throw new NotImplementedException();
    }

    [HttpPost("end-shift/{employee-id:int}/{time:datetime=now}/{date:datetime=now}")]
    public ActionResult<string> EndShift(int employeeId, TimeOnly time, DateOnly date)
    {
        throw new NotImplementedException();
    }
}