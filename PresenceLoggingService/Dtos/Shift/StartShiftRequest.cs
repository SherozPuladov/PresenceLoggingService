namespace PresenceLoggingService.Dtos.Shift;

public record StartShiftRequest(
    TimeOnly StartShift,
    DateOnly ShiftDate);