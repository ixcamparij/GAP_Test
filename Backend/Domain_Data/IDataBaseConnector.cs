using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data
{
    public interface IDataBaseConnector
    {
        Task<User> GetUserByIdAsync(int id);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<Customer> GetCustomerByIdAsync(int id);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Policy> GetPolicyByIdAsync(int id);

        Task<IEnumerable<Policy>> GetPoliciesAsync();

        Task CreatePolicyAsync(Policy policy);

        Task UpdatePolicyAsync(Policy policy);

        Task DeletePolicyAsync(int id);
    }
}
