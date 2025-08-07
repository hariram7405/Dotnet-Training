using AutoMapper;
using EmployeeMapper.Core.Entities;
using EmployeeMapper.Core.DTOs;

namespace EmployeeMapper.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        
            CreateMap<Department, DepartmentRequestDTO>().ReverseMap();
            CreateMap<Department, DepartmentResponseDTO>().ReverseMap();

     
            CreateMap<Employee, EmployeeRequestDTO>().ReverseMap();
            CreateMap<Employee, EmployeeResponseDTO>().ReverseMap();
        }
    }
}
