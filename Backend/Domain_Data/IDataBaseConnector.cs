using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data
{
    public interface IDataBaseConnector
    {
        Task<Customer> GetCustomerById(int id);

        Task<IEnumerable<Customer>> GetCustomers();

        Task<User> GetUserById(int id);

        Task<Policy> GetPolicyById(int id);

        Task<IEnumerable<Policy>> GetPolicies();

        Task CreatePolicy(Policy policy);

        Task UpdatePolicy(Policy policy);

        Task DeletePolicy(int id);
    }
}
