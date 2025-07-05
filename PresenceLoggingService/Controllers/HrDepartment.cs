using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresenceLoggingService.Data;
using PresenceLoggingService.Dtos.Employee;
using PresenceLoggingService.Dtos.Role;
using PresenceLoggingService.Models;

namespace PresenceLoggingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HrDepartment(IHrDepartmentRepo repository, IMapper mapper) : Controller
{
    [HttpGet("role")]
    public async Task<ActionResult<IEnumerable<RoleReadDto>>> GetAllRoles()
    {
        var result = await repository.GetAllRolesAsync();
        return result.Success
            ? Ok(mapper.Map<IEnumerable<RoleReadDto>>(result.Data))
            : BadRequest(result.Exception?.Message);
    }
    
    [HttpGet("role/{id:int}")]
    public async Task<ActionResult<RoleReadDto>> GetRole(int id)
    {
        var result = await repository.GetRoleAsync(id);
        return result.Success
            ? Ok(mapper.Map<RoleReadDto>(result.Data))
            : BadRequest(result.Exception?.Message);
    }
    
    [HttpPost("role")]
    public async Task<ActionResult<Role>> CreateRole(RoleCreateDto roleDto)
    {
        var role = mapper.Map<Role>(roleDto);
        var result = await repository.CreateRoleAsync(role);
        
        if (!result.Success)
            return BadRequest(result.Exception?.Message);
        
        var readRole = await repository.GetRoleAsync(role.RoleId);
        if (!readRole.Success)
            return BadRequest(readRole.Exception?.Message);
        
        var roleReadDto = mapper.Map<RoleReadDto>(readRole.Data);
        return CreatedAtAction(nameof(GetRole), new {id = roleReadDto.RoleId}, roleReadDto);
    }
    
    [HttpPut("role")]
    public async Task<ActionResult<RoleReadDto>> UpdateRole(RoleUpdateDto roleDto)
    {
        var role = mapper.Map<Role>(roleDto);
        var result = await repository.UpdateRoleAsync(role);
        
        if (!result.Success)
            return BadRequest(result.Exception?.Message);
        
        var readRole = await repository.GetRoleAsync(role.RoleId);
        if (!readRole.Success)
            return BadRequest(readRole.Exception?.Message);
        
        return Ok(mapper.Map<RoleReadDto>(readRole.Data));
    }
    
    [HttpDelete("role/{id:int}")]
    public async Task<ActionResult<bool>> DeleteRole(int id)
    {
        var result = await repository.DeleteRoleAsync(id);
        return result.Success
            ? NoContent()
            : BadRequest(result.Exception?.Message);
    }
    
    [HttpGet("employee")]
    public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAllEmployees()
    {
        var result = await repository.GetAllEmployeesAsync();
        return result.Success
            ? Ok(mapper.Map<IEnumerable<EmployeeReadDto>>(result.Data))
            : BadRequest(result.Exception?.Message);
    }
    
    [HttpGet("employee/{id:int}")]
    public async Task<ActionResult<EmployeeReadDto>> GetEmployee(int id)
    {
        var result = await repository.GetEmployeeAsync(id);
        return result.Success
            ? Ok(mapper.Map<EmployeeReadDto>(result.Data))
            : BadRequest(result.Exception?.Message);
    }
    
    [HttpPost("employee")]
    public async Task<ActionResult<Employee>> CreateEmployee(EmployeeCreateDto employeeDto)
    {
        var employee = mapper.Map<Employee>(employeeDto);
        var result = await repository.CreateEmployeeAsync(employee);
        
        if (!result.Success)
            return BadRequest(result.Exception?.Message);
        
        var readEmployee = await repository.GetEmployeeAsync(employee.EmployeeId);
        return readEmployee.Success
            ? CreatedAtAction(nameof(GetEmployee), new { id = readEmployee.Data.EmployeeId }, readEmployee.Data)
            : BadRequest(readEmployee.Exception?.Message);
    }
    
    [HttpPut("employee")]
    public async Task<ActionResult<EmployeeReadDto>> UpdateEmployee(EmployeeUpdateDto employeeDto)
    {
        var employee = mapper.Map<Employee>(employeeDto);
        var result = await repository.UpdateEmployeeAsync(employee);
        
        return result.Success
            ? Ok(mapper.Map<EmployeeReadDto>(result.Data))    
            : BadRequest(result.Exception?.Message);
    }
    
    [HttpDelete("employee/{id:int}")]
    public async Task<ActionResult<bool>> DeleteEmployee(int id)
    {
        var result = await repository.DeleteEmployeeAsync(id);
        return result.Success
            ? NoContent()
            : BadRequest(result.Exception?.Message);   
    }

    [HttpGet("employee/get-employees-by-role/{roleId:int}")]
    public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetEmployeesByRole(int roleId)
    {
        var result = await repository.GetEmployeesByRoleAsync(roleId);
        return result.Success
            ? Ok(mapper.Map<IEnumerable<EmployeeReadDto>>(result.Data))
            : BadRequest(result.Exception?.Message);   
    }
}