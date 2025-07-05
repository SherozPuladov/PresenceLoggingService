namespace PresenceLoggingService.Dtos.Shift;

public record EndShiftRequest(
    TimeOnly EndShift,
    DateOnly ShiftDate);