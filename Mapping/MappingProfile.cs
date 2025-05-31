using AutoMapper;
using HRMS.API.Dtos;
using HRMS.API.Models;

namespace HRMS.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<Employee, EmployeeResponseDto>();
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<Department, DepartmentResponseDto>();
        }
    }

}