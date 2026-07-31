using CachingInApis.Dtos;
using CachingInApis.Models;
using CachingInApis.Services;
using Microsoft.AspNetCore.Mvc;

namespace CachingInApis.Controllers
{
    [ApiController]
    public class DepartmentApiController : ControllerBase
    {
        IDepartmentService departmentService;
        public DepartmentApiController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        [HttpGet]
        [Route("api/department")]
        public List<DepartmentDto> GetDepartments()
        {
            return departmentService.GetDepartments();
        }
        [HttpGet]
        [Route("api/department/{id}")]
        public  DepartmentDto  GetDepartment(int id)
        {
            return departmentService.GetDepartment(id);
        }


    }
}
