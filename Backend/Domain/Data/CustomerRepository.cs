using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository() 
        {
        
        }

        public async Task<Customer> GetCustomerById(string id) 
        {
            await Task.CompletedTask;

            if (id == "1")
            {
                return new Customer() { Id = "1", Name = "Ixcam" };
            }

            return null;
        }

        public async Task<IEnumerable<Customer>> GetCustomers() 
        {
            await Task.CompletedTask;
            var customer1 = new Customer() { Id = "1", Name = "Ixcam" };
            var customer2 = new Customer() { Id = "2", Name = "Manuel" };

            return new List<Customer>() { customer1, customer2 };
        }
    }
}
