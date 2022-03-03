using LuftbornTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuftbornTask.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext context;

        public CustomerService(AppDbContext context)
        {
            this.context = context;
        }


        public async Task AddCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            context.SaveChanges();
        }

        public async Task DeleteCustomer(int id)
        {
            var selectedCustomer = await GetCustomer(id);
            context.Customers.Remove(selectedCustomer);
            context.SaveChanges();
        }

        public async Task EditCustomer(int id, Customer customer)
        {
            var selectedCustomer = await GetCustomer(id);

            selectedCustomer.LastName = customer.LastName;
            selectedCustomer.FirstName = customer.FirstName;
            selectedCustomer.Email = customer.Email;
            selectedCustomer.PhoneNumber = customer.PhoneNumber;
            context.SaveChanges();

        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(c=>c.Id==id);
            return customer;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await context.Customers.ToListAsync();
            return customers;
        }
    }
}
