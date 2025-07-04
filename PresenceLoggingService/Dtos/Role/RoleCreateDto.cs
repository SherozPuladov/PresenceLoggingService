using System.ComponentModel.DataAnnotations;
using PresenceLoggingService.Models;

namespace PresenceLoggingService.Dtos.Role;

public class RoleCreateDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public TimeOnly RoleStartShift { get; set; }
    
    [Required]
    public TimeOnly RoleEndShift { get; set; }
}