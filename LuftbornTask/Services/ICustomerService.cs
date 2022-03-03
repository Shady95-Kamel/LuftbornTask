using LuftbornTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuftbornTask.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
        Task AddCustomer(Customer customer);
        Task EditCustomer(int id, Customer customer);
        Task DeleteCustomer(int id);
    }
}
