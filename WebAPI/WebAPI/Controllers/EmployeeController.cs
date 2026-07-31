using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        ProjectContext db;
        public EmployeeController(ProjectContext db)
        { 
                   this.db= db;
        }
        [HttpGet]
        [Route("api/tblemp")]
        public List<Tblemp> GetAll()
        {
            List<Tblemp> lst = db.Tblemps.ToList();
            return lst;
        }
        [HttpGet]
        [Route("api/tblemp/{id}")]
        public Tblemp Getbyid(int id)
        {
            return db.Tblemps.Find(id);
        }
        [HttpPost]
        [Route("api/tblemp")]
        public Tblemp Addemp(Tblemp emp)
        {
            db.Tblemps.Add(emp);
            db.SaveChanges();
            return emp;
            
        }
        [HttpPut]
        [Route("api/tblemp")]
        public Tblemp Update(Tblemp emp)
        {
            db.Tblemps.Update(emp);
            db.SaveChanges();
            return emp;
        }
        [HttpDelete]
        [Route("api/tblemp")]
        public Tblemp delete(Tblemp emp)
        {

            db.Tblemps.Remove(emp);
            db.SaveChanges();
            return emp;

        }
    }
}
