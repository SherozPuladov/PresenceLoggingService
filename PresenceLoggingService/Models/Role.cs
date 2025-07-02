using System.ComponentModel.DataAnnotations;

namespace PresenceLoggingService.Models;

public class Role
{
    [Key]
    [Required]
    public int RoleId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    public TimeOnly RoleStartShift { get; set; }
    
    [Required]
    public TimeOnly RoleEndShift { get; set; }
    
    public List<Employee> Employees { get; set; } = new();
}