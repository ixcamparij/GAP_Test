using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerById(string id);

        Task<IEnumerable<Customer>> GetCustomers();
    }
}
