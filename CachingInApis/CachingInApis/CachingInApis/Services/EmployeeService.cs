using AutoMapper;
using CachingInApis.Dtos;
using CachingInApis.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CachingInApis.Services
{
    public class EmployeeService : IEmployeeService
    {
        AdventureWorks2014Context _db;
        //IMemoryCache cache;
        ICacheService<EmployeeDto> cacheService;
        IMapper mapper;
        public EmployeeService(AdventureWorks2014Context db, ICacheService<EmployeeDto> cacheService,IMapper mapper)
        {
           _db = db;
            this.cacheService = cacheService;
            this.mapper = mapper;

        }
        public List<EmployeeDto> GetEmployees()
        {
            var cacheData = cacheService.GetCacheData("employees");
            if (cacheData != null)
            {
                return cacheData;
            }
            else
            {
                List<Employee> lst = _db.Employees.ToList();
                List<EmployeeDto> employeelist = mapper.Map<List<EmployeeDto>>(lst);
               
               // cacheData = lst;
                var timeoffset = DateTimeOffset.Now.AddMinutes(10);
                cacheService.SetCacheData("employees", employeelist, timeoffset);
                return employeelist;
            }


        }
    }
}
