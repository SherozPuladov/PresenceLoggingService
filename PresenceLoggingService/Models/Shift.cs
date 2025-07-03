using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresenceLoggingService.Models;

public class Shift
{
    [Key]
    [Required]
    public int ShiftId { get; set; }
    
    [Required]
    public DateOnly ShiftDate { get; set; }
    
    [Required]
    public TimeOnly StartShift { get; set; }
    
    public TimeOnly? EndShift { get; set; }
    
    
    public TimeSpan WorkedHours { get; set; }
    
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}