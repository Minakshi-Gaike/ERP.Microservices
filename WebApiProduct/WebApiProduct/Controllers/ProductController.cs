using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using WebApiProduct.Models;

namespace WebApiProduct.Controllers
{
    [Authorize]

    //[Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        JwtdbContext db;
        public ProductController(JwtdbContext db)
        {
            this.db = db;
        }

        [HttpGet]

        [Route("api/Product")]
        public List<TblProduct> GetAll()
        {
            List<TblProduct> lst = db.TblProducts.ToList();
            return lst;
        }
        [HttpGet]
        [Route("api/Product/{id}")]
        public TblProduct Getbyid(int id)
        {
            return db.TblProducts.Find(id);
        }

        
    }
}
