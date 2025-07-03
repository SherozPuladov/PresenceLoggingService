using PresenceLoggingService.Models;

namespace PresenceLoggingService.Data;

public interface ISecurityCheckpointRepo
{
    Task<OperationResult<bool>> StartShiftAsync(int employeeId, TimeOnly startShift, DateOnly shiftDate);
    Task<OperationResult<bool>> EndShiftAsync(int employeeId, TimeOnly endShift, DateOnly shiftDate);
}