using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresenceLoggingService.Models;

public class Employee
{
    [Key]
    [Required]
    public int EmployeeId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    [StringLength(50)]
    public string? ThirdName { get; set; }
    
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }

    public List<Shift> Shifts { get; set; } = new();
    
    [ForeignKey("LastShift")]
    public int LastShiftId { get; set; }
    public Shift LastShift { get; set; }
}