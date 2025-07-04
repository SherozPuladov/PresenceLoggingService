using System.ComponentModel.DataAnnotations;

namespace PresenceLoggingService.Dtos.Role;

public class RoleReadDto
{
    public int RoleId { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    
    public TimeOnly RoleStartShift { get; set; }
    
    public TimeOnly RoleEndShift { get; set; }
}