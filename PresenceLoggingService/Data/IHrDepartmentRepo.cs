using PresenceLoggingService.Models;

namespace PresenceLoggingService.Data;

public interface IHrDepartmentRepo
{
    Task<OperationResult<Employee>> GetEmployeeAsync(int id);
    Task<OperationResult<bool>> CreateEmployeeAsync(Employee employee);
    Task<OperationResult<bool>> UpdateEmployeeAsync(Employee employee);
    Task<OperationResult<bool>> DeleteEmployeeAsync(int id);
    Task<OperationResult<IEnumerable<Employee>>> GetAllEmployeesAsync();
    
    Task<OperationResult<IEnumerable<Employee>>> GetEmployeesByRoleAsync(int roleId);
    
    Task<OperationResult<Role>> GetRoleAsync(int id);
    Task<OperationResult<bool>> CreateRoleAsync(Role role);
    Task<OperationResult<bool>> UpdateRoleAsync(Role role);
    Task<OperationResult<bool>> DeleteRoleAsync(int id);
    Task<OperationResult<IEnumerable<Role>>> GetAllRolesAsync();
}