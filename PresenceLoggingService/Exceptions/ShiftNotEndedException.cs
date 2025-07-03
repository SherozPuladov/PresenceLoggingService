namespace PresenceLoggingService.Exceptions;

public class ShiftNotEndedException : Exception
{
    public ShiftNotEndedException(int employeeId)
        : base($"Работник с ID: {employeeId} не закончил предыдушую смену")
    { }
}