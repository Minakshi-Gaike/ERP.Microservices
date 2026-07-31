using AutoMapper;
using CachingInApis.Dtos;
using CachingInApis.Models;

namespace CachingInApis.Services
{
    public class DepartmentService : IDepartmentService
    {
        AdventureWorks2014Context _db;
        ICacheService<DepartmentDto> cacheService;
        IMapper mapper;
        public DepartmentService(ICacheService<DepartmentDto> cacheService,AdventureWorks2014Context db,IMapper mapper)
        {
            this.cacheService = cacheService;
            _db = db;
            this.mapper = mapper;
        }
        public DepartmentDto GetDepartment(int id)
        {

            if (cacheService.GetSingleObjectCacheData("department") != null)
            {
                return (DepartmentDto)cacheService.GetSingleObjectCacheData("department");
            }
            Department d = _db.Departments.FirstOrDefault(e=>e.DepartmentId.Equals((short)id));
            DepartmentDto dept = mapper.Map<DepartmentDto>(d);
            DateTimeOffset timeoffset = DateTimeOffset.Now.AddMinutes(10);
            cacheService.SetSingleObjectCacheData("department", dept, timeoffset);
            return dept;

        }

        public List<DepartmentDto> GetDepartments()
        {
            if (cacheService.GetCacheData("departments") != null)
            {
                return (List<DepartmentDto>)cacheService.GetCacheData("departments");
            }

            List<Department> lst = _db.Departments.ToList();
            List<DepartmentDto> departments = mapper.Map<List<DepartmentDto>>(lst);
            DateTimeOffset timeoffset = DateTimeOffset.Now.AddMinutes(10);
            cacheService.SetCacheData("departments", departments, timeoffset);
            return departments;
        }
    }
}
