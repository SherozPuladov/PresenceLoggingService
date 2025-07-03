using Microsoft.EntityFrameworkCore;
using PresenceLoggingService.Exceptions;
using PresenceLoggingService.Models;

namespace PresenceLoggingService.Data;

public class SecurityCheckpointRepo(AppDbContext context) : ISecurityCheckpointRepo
{
    public async Task<OperationResult<bool>> StartShiftAsync(int employeeId, TimeOnly startShift, DateOnly shiftDate)
    {
        try
        {
            var employee = await context.Employees
                .Include(e => e.LastShift)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (employee == null)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Employee), employeeId));
            
            if (employee.LastShift?.EndShift == null)
                return OperationResult<bool>.Error(
                    new ShiftNotEndedException(employeeId));

            var shift = new Shift()
            {
                StartShift = startShift,
                EndShift = null,
                EmployeeId = employeeId,
                ShiftDate = shiftDate
            };
            
            context.Shifts.Add(shift);
            employee.LastShift = shift;
            await context.SaveChangesAsync();
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);
        }
    }

    public async Task<OperationResult<bool>> EndShiftAsync(int employeeId, TimeOnly endShift, DateOnly shiftDate)
    {
        try
        {
            var employee = await context.Employees
                .Include(e => e.LastShift)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee == null)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Employee), employeeId));

            if (employee.LastShift?.ShiftDate != shiftDate)
                return OperationResult<bool>.Error(
                    new ShiftNotStartedException(employeeId));

            employee.LastShift.EndShift = endShift;
            employee.LastShift.WorkedHours = endShift - employee.LastShift.StartShift;
            await context.SaveChangesAsync();
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);
        }
    }
}