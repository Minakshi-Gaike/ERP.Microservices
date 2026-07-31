using CachingInApis.Dtos;
using CachingInApis.Models;
using CachingInApis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CachingInApis.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("api/employee")]
        public List<EmployeeDto> GetAllEmployees()
        {
            return _employeeService.GetEmployees();
        }
    }
}
