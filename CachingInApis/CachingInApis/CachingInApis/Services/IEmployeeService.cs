using CachingInApis.Dtos;
using CachingInApis.Models;

namespace CachingInApis.Services
{
    public interface IEmployeeService
    {

        List<EmployeeDto> GetEmployees();
    }
}
