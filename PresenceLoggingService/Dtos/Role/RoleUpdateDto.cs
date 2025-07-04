using System.ComponentModel.DataAnnotations;
using PresenceLoggingService.Models;

namespace PresenceLoggingService.Dtos.Role;

public class RoleUpdateDto
{
    public int RoleId { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    
    public TimeOnly RoleStartShift { get; set; }
    
    public TimeOnly RoleEndShift { get; set; }
}