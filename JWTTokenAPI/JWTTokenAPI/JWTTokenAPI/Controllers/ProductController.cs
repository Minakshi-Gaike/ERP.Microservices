using JWTTokenAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTTokenAPI.Controllers
{
   [Authorize]
  //  [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        JwtdbContext db;

        public ProductController(JwtdbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("api/employee")]
        public List<TblEmployee> GetAllEmployees ()
        {
            List<TblEmployee> lst = db.TblEmployees.ToList();
            return lst;
        }

        [HttpGet]
        [Route("api/employee/{pid}")]
        public TblEmployee GetEmployeeById(int pid)
        {
            var e = db.TblEmployees.Find(pid);
            return e;
        }
    }
}
