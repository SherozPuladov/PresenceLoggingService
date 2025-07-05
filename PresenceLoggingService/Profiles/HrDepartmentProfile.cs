using AutoMapper;
using PresenceLoggingService.Dtos.Employee;
using PresenceLoggingService.Dtos.Role;
using PresenceLoggingService.Models;

namespace PresenceLoggingService.Profiles;

public class HrDepartmentProfile : Profile
{
    public HrDepartmentProfile()
    {
        CreateMap<Employee, EmployeeReadDto>();
        CreateMap<EmployeeCreateDto, Employee>();
        CreateMap<EmployeeUpdateDto, Employee>();
        CreateMap<EmployeeUpdateDto, EmployeeReadDto>();
        
        CreateMap<Role, RoleReadDto>();
        CreateMap<RoleCreateDto, Role>();
        CreateMap<RoleUpdateDto, Role>();
        CreateMap<RoleUpdateDto, RoleReadDto>();
    }
    
}