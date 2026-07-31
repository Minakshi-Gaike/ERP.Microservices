using AutoMapper;
using CachingInApis.Dtos;

namespace CachingInApis.Models
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<Department, DepartmentDto>()
                .ForMember(d => d.DepartmentId, op => op.MapFrom(s => s.DepartmentId))
                //.ForMember(d => d.DepartmentGroupName, op => op.MapFrom(s => s.GroupName))
                .ForMember(d => d.DepartmentName, op => op.MapFrom(s => s.Name)); 

        }
    }
}
