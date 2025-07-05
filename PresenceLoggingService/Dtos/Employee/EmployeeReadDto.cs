namespace PresenceLoggingService.Dtos.Employee;

public class EmployeeReadDto
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ThirdName { get; set; }
    public int RoleId { get; set; }
}