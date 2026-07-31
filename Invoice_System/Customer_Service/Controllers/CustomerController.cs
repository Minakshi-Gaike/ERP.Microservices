using Customer_Service.Models;
using Customer_Service.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       // private readonly InvoiceDbContext _context;
        private readonly ICustomerRepository _customer;
        public CustomerController( ICustomerRepository customer)
        {
            _customer = customer;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result= await _customer.GetAll();
            return Ok(result);
        }
    }
}
