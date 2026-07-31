using CachingInApis.Dtos;
using CachingInApis.Models;

namespace CachingInApis.Services
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetDepartments();
        DepartmentDto GetDepartment(int id);
    }
}
