using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresenceLoggingService.Data;
using PresenceLoggingService.Dtos.Shift;

namespace PresenceLoggingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecurityCheckpoint(ISecurityCheckpointRepo repository, IMapper mapper) : Controller
{
    [HttpPost("start-shift/{employeeId:int}")]
    public async Task<ActionResult> StartShift(
        int employeeId,
        [FromBody] StartShiftRequest startShiftRequest)
    {
        var result = await repository.StartShiftAsync(employeeId, startShiftRequest.StartShift, startShiftRequest.ShiftDate);
        
        return result.Success
            ? Ok()
            : BadRequest(result.Exception?.Message);
    }

    [HttpPost("end-shift/{employeeId:int}")]
    public async Task<ActionResult> EndShift(
        int employeeId, 
        [FromBody] EndShiftRequest endShiftRequest)
    {
        var result = await repository.EndShiftAsync(employeeId, endShiftRequest.EndShift, endShiftRequest.ShiftDate);
        
        return result.Success
            ? Ok()
            : BadRequest(result.Exception?.Message);   
    }
}