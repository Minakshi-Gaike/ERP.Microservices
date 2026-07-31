using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        InvoiceDbContext _db;
        public ProductController(InvoiceDbContext db)
        {
            _db = db;
        }
    }
}
