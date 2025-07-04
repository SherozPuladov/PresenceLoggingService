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
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (employee == null)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Employee), employeeId));
            
            if (employee.LastShiftId.HasValue)
            {
                var lastShift = await context.Shifts.FindAsync(employee.LastShiftId);
                if (lastShift?.EndShift == null)
                    return OperationResult<bool>.Error(
                        new ShiftNotEndedException(employeeId));
            }

            var shift = new Shift()
            {
                StartShift = startShift,
                EndShift = null,
                EmployeeId = employeeId,
                ShiftDate = shiftDate
            };
            
            await context.Shifts.AddAsync(shift);
            await context.SaveChangesAsync();
            
            employee.LastShiftId = shift.ShiftId;
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
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee == null)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Employee), employeeId));

            if (!employee.LastShiftId.HasValue)
                return OperationResult<bool>.Error(
                    new ShiftNotStartedException(employeeId));
            
            var lastShift = await context.Shifts.FindAsync(employee.LastShiftId);
            
            if (lastShift?.ShiftDate != shiftDate)
                return OperationResult<bool>.Error(
                    new ShiftNotStartedException(employeeId));
            
            
            
            lastShift.EndShift = endShift;
            lastShift.WorkedHours = endShift - lastShift.StartShift;
            await context.SaveChangesAsync();
            
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);
        }
    }
}