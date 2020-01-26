using Domain_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Data.Data
{
    public interface IPolicyRepository
    {
        Task<Policy> GetPolicyById(int id);

        Task<IEnumerable<Policy>> GetPolicies();

        Task CreatePolicy(Policy user);

        Task UpdatePolicy(Policy user);

        Task DeletePolicy(int id);
    }
}
