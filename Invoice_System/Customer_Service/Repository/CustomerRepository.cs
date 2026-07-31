using Customer_Service.Models;
using Microsoft.EntityFrameworkCore;


using Customer_Service.DTOs;

namespace Customer_Service.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        InvoiceDbContext _context;
        public CustomerRepository(InvoiceDbContext context)
        {
            _context = context;
        }
        

        async Task<List<Tblcustomer>> ICustomerRepository.GetAll()
        {
            var customers = await _context.Tblcustomers.ToListAsync();
            return customers;
        }
    }
}
