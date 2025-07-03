using PresenceLoggingService.Models;

namespace PresenceLoggingService.Data;

public interface ISecurityCheckpointRepo
{
    Task<OperationResult<bool>> StartShiftAsync(int id, TimeOnly startShift, DateOnly shiftDate);
    Task<OperationResult<bool>> EndShiftAsync(int id, TimeOnly endShift, DateOnly shiftDate);
}