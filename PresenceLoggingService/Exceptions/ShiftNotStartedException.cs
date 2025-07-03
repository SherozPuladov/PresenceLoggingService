namespace PresenceLoggingService.Exceptions;

public class ShiftNotStartedException : Exception
{
    public ShiftNotStartedException(int employeeId)
        : base($"Работник с ID: {employeeId} не начав смену хочет его завершить")
    { }
}