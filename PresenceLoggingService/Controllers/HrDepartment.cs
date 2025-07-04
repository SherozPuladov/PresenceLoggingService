using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresenceLoggingService.Data;
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
}