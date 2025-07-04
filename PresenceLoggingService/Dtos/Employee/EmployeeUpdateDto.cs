using System.ComponentModel.DataAnnotations;

namespace PresenceLoggingService.Dtos.Employee;

public class EmployeeUpdateDto
{
    public int EmployeeId { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(50)]
    public string? ThirdName { get; set; }
    
    [Required]
    public int RoleId { get; set; }

}