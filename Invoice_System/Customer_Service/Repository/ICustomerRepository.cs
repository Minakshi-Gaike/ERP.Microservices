using Customer_Service.Models;

namespace Customer_Service.Repository
{
    public interface ICustomerRepository
    {
        //void <List (Tblcustomer)> GetAll();
         Task <List<Tblcustomer>> GetAll();
    }
}
