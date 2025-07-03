using Microsoft.EntityFrameworkCore;
using PresenceLoggingService.Exceptions;
using PresenceLoggingService.Models;

namespace PresenceLoggingService.Data;

public class HrDepartmentRepo(AppDbContext context) : IHrDepartmentRepo
{
    public async Task<OperationResult<Employee>> GetEmployeeAsync(int id)
    {
        try
        {
            var e = await context.Employees.FindAsync(id);

            return e != null
                ? OperationResult<Employee>.Ok(e)
                : OperationResult<Employee>.Error(
                    new EntityNotFoundException(nameof(Employee), id));
        }
        catch (Exception exception)
        {
            return OperationResult<Employee>.Error(exception);      
        }
    }

    public async Task<OperationResult<bool>> CreateEmployeeAsync(Employee employee)
    {
        try
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);
        }
    }

    public async Task<OperationResult<bool>> UpdateEmployeeAsync(Employee employee)
    {
        try
        {
            var exists = await context.Employees.AnyAsync(e => e.EmployeeId == employee.EmployeeId);
            if (!exists)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Employee), employee.EmployeeId));
            
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);
        }
    }

    public async Task<OperationResult<bool>> DeleteEmployeeAsync(int id)
    {
        try
        {
            var employee = await context.Employees.FindAsync(id);
            
            if (employee == null)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Employee), id));
            
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);
        }
    }

    public async Task<OperationResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
    {
        try
        {
            return OperationResult<IEnumerable<Employee>>.Ok(await context.Employees.ToListAsync());
        }
        catch (Exception exception)
        {
            return OperationResult<IEnumerable<Employee>>.Error(exception);      
        }
    }

    public async Task<OperationResult<IEnumerable<Employee>>> GetEmployeesByRoleAsync(int roleId)
    {
        try
        {
            var roleExists = await context.Roles.AnyAsync(r => r.RoleId == roleId);
            if (!roleExists)
                return OperationResult<IEnumerable<Employee>>.Error(
                    new EntityNotFoundException(nameof(Role), roleId));
            
            return OperationResult<IEnumerable<Employee>>.Ok(await context.Employees
                .Where(e => e.RoleId == roleId)
                .ToListAsync());
        }
        catch (Exception exception)
        {
            return OperationResult<IEnumerable<Employee>>.Error(exception);      
        }
    }

    public async Task<OperationResult<Role>> GetRoleAsync(int id)
    {
        try
        {
            var r = await context.Roles.FindAsync(id);
            return r != null
                ? OperationResult<Role>.Ok(r)
                : OperationResult<Role>.Error(
                    new EntityNotFoundException(nameof(Role), id));
        }
        catch (Exception exception)
        {
            return OperationResult<Role>.Error(exception);     
        }
        
    }

    public async Task<OperationResult<bool>> CreateRoleAsync(Role role)
    {
        try
        {
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);       
        }
    }

    public async Task<OperationResult<bool>> UpdateRoleAsync(Role role)
    {
        try
        {
            var exists = await context.Roles.AnyAsync(r => r.RoleId == role.RoleId);
            if (!exists)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Role), role.RoleId));
            
            context.Roles.Update(role);
            await context.SaveChangesAsync();
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);       
        }
    }

    public async Task<OperationResult<bool>> DeleteRoleAsync(int id)
    {
        try
        {
            var role = await context.Roles.FindAsync(id);
            
            if (role == null)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Role), id));
            
            context.Roles.Remove(role);
            await context.SaveChangesAsync();
            return OperationResult<bool>.Ok(true);
        }
        catch (Exception exception)
        {
            return OperationResult<bool>.Error(exception);      
        }
    }

    public async Task<OperationResult<IEnumerable<Role>>> GetAllRolesAsync()
    {
        try
        {
            return OperationResult<IEnumerable<Role>>.Ok(await context.Roles.ToListAsync());
        }
        catch (Exception exception)
        {
            return OperationResult<IEnumerable<Role>>.Error(exception);     
        }
    }
}