using Microsoft.EntityFrameworkCore;
using PresenceLoggingService.Exceptions;
using PresenceLoggingService.Models;

namespace PresenceLoggingService.Data;

public class HrDepartmentRepo : IHrDepartmentRepo
{
    private readonly AppDbContext _context;
    
    public HrDepartmentRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<OperationResult<Employee>> GetEmployeeAsync(int id)
    {
        try
        {
            var e = await _context.Employees.FindAsync(id);

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
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
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
            var exists = await _context.Employees.AnyAsync(e => e.EmployeeId == employee.EmployeeId);
            if (!exists)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Employee), employee.EmployeeId));
            
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
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
            var employee = await _context.Employees.FindAsync(id);
            
            if (employee == null)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Employee), id));
            
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
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
            return OperationResult<IEnumerable<Employee>>.Ok(await _context.Employees.ToListAsync());
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
            var roleExists = await _context.Roles.AnyAsync(r => r.RoleId == roleId);
            if (!roleExists)
                return OperationResult<IEnumerable<Employee>>.Error(
                    new EntityNotFoundException(nameof(Role), roleId));
            
            return OperationResult<IEnumerable<Employee>>.Ok(await _context.Employees
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
            var r = await _context.Roles.FindAsync(id);
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
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
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
            var exists = await _context.Roles.AnyAsync(r => r.RoleId == role.RoleId);
            if (!exists)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Role), role.RoleId));
            
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
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
            var role = await _context.Roles.FindAsync(id);
            
            if (role == null)
                return OperationResult<bool>.Error(
                    new EntityNotFoundException(nameof(Role), id));
            
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
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
            return OperationResult<IEnumerable<Role>>.Ok(await _context.Roles.ToListAsync());
        }
        catch (Exception exception)
        {
            return OperationResult<IEnumerable<Role>>.Error(exception);     
        }
    }
}